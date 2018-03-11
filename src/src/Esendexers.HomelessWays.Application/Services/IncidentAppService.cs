using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using Esendexers.HomelessWays.DTOs;
using Esendexers.HomelessWays.Entities;
using Esendexers.HomelessWays.Inputs;
using GeoCoordinatePortable;

namespace Esendexers.HomelessWays.Services
{
    public interface IIncidentAppService
    {
        bool RecordNewIncident(CreateIncidentInput incidentRequest);
        Task<IEnumerable<IncidentDto>> GetIncidentsAroundLocation(double latitude, double longitude, uint radius);

        Task<IEnumerable<IncidentDto>> GetIncidentsAroundLocationWithTag(double latitude, double longitude, uint radius, string tag);
        Task<IEnumerable<IncidentDto>> GetIncidentsWithTag(string tag);
        Task<IEnumerable<IncidentDto>> GetIncidentsAroundLocationOrderBySentiment(double latitude, double longitude, uint radius);
    }

    public class IncidentAppService : HomelessWaysAppServiceBase, IIncidentAppService
    {
        private readonly ILanguageAnalysysService _languageAnalysys;
        private readonly IImageAnalysisService _imageAnalysisService;

        private readonly IRepository<Incident> _incidentRepository;
        private readonly IRepository<Image> _imageRepository;
        private readonly IRepository<Tag> _tagRepository;
        private readonly IRepository<IncidentTag> _incidentTagRepository;

        private readonly IObjectMapper _objectMapper;

        public IncidentAppService(ILanguageAnalysysService languageAnalysys, IRepository<Incident> incidentRepository, IObjectMapper objectMapper, IRepository<Tag> tagRepository, IRepository<IncidentTag> incidentTagRepository, IRepository<Image> imageRepository, IImageAnalysisService imageAnalysisService)
        {
            _languageAnalysys = languageAnalysys;
            _incidentRepository = incidentRepository;
            _objectMapper = objectMapper;
            _tagRepository = tagRepository;
            _incidentTagRepository = incidentTagRepository;
            _imageRepository = imageRepository;
            _imageAnalysisService = imageAnalysisService;
        }

        public bool RecordNewIncident(CreateIncidentInput incidentRequest)
        {
            var incident = _objectMapper.Map<Incident>(incidentRequest);
            incident.PositivitySentimentScore = _languageAnalysys.GetSentimentScore(incident.Description);

            var phrases = _languageAnalysys.GetKeyPrases(incident.Description);
            var incidentTags = (from phrase in phrases
                let databasePhrase = _tagRepository.GetAll().FirstOrDefault(tag => tag.Name == phrase)
                select databasePhrase == null
                    ? _tagRepository.InsertAndGetId(new Tag {Name = phrase})
                    : databasePhrase.Id).ToList();

            var imageTags = _imageAnalysisService.AnalyzeImage(incidentRequest.ImageBytes).Result.Description.Tags;
            incidentTags.AddRange((from imageTag in imageTags
                let databasePhrase = _tagRepository.GetAll().FirstOrDefault(tag => tag.Name == imageTag)
                select databasePhrase == null
                    ? _tagRepository.InsertAndGetId(new Tag {Name = imageTag})
                    : databasePhrase.Id).ToList());

            incident.ImageId = _imageRepository.InsertAndGetId(new Image { ImagePath = incidentRequest.ImageName });
            var incidentId = _incidentRepository.InsertAndGetId(incident);

            foreach (var incidentTag in incidentTags)
            {
                _incidentTagRepository.Insert(new IncidentTag{IncidentId = incidentId, TagId = incidentTag });
            }
            return true;
        }

        public async Task<IEnumerable<IncidentDto>> GetIncidentsAroundLocation(double latitude, double longitude, uint radius)
        {
            var currentCoordinate = new GeoCoordinate(latitude, longitude);
            var answers = (await _incidentRepository.GetAllListAsync()).ToList()
                .Select(async i => await MapNearby(i, radius, currentCoordinate))
                .Where(i => i != null);

            return answers.Select(task => task.Result).ToList();
        }
        public async Task<IEnumerable<IncidentDto>> GetIncidentsAroundLocationOrderBySentiment(double latitude, double longitude, uint radius)
        {
            var currentCoordinate = new GeoCoordinate(latitude, longitude);
            var incidentDtos = (await _incidentRepository.GetAllListAsync()).ToList()
                .Select(async i => await MapNearby(i, radius, currentCoordinate))
                .Where(i => i != null)
                .OrderBy(dto => dto.Result.PositivitySentimentScore)
                .ToList();

            return incidentDtos.Select(task => task.Result).ToList();
        }

        public async Task<IEnumerable<IncidentDto>> GetIncidentsAroundLocationWithTag(double latitude, double longitude, uint radius, string tag)
        {
            var nearbyIncidents = await GetIncidentsAroundLocation(latitude, longitude, radius);
            var tagsWithNameIds = (await _tagRepository.GetAllListAsync()).Where(dbTag => dbTag.Name == tag).Select(dbTag => dbTag.Id);

            var incidentTags = (await _incidentTagRepository.GetAllListAsync()).Where(incidentTag =>
                tagsWithNameIds.Any(i => i == incidentTag.TagId) &&
                nearbyIncidents.Any(dto => dto.Id == incidentTag.IncidentId));

            return nearbyIncidents.Where(dto => incidentTags.Any(incidentTag => incidentTag.IncidentId == dto.Id));
        }

        public async Task<IEnumerable<IncidentDto>> GetIncidentsWithTag(string tag)
        {
            var allIncidents = await _incidentRepository.GetAllListAsync();
            var incidents = new List<IncidentDto>();
            foreach (var incident in allIncidents)
            {
                incidents.Add(await Map(incident));
            }

            var tagsWithNameIds = (await _tagRepository.GetAllListAsync()).Where(dbTag => dbTag.Name == tag).Select(dbTag => dbTag.Id);

            var incidentTags = (await _incidentTagRepository.GetAllListAsync()).Where(incidentTag =>
                tagsWithNameIds.Any(i => i == incidentTag.TagId) &&
                incidents.Any(dto => dto.Id == incidentTag.IncidentId));

            return incidents.Where(dto => incidentTags.Any(incidentTag => incidentTag.IncidentId == dto.Id));
        }

        private async Task<IncidentDto> MapNearby(Incident incident, uint radius, GeoCoordinate currentCoordinate)
        {
            var incidentCoordinate = new GeoCoordinate(double.Parse(incident.Latitude), double.Parse(incident.Longitude));
            var returnMe = currentCoordinate.GetDistanceTo(incidentCoordinate) < radius ? _objectMapper.Map<IncidentDto>(incident) : null;
            if (returnMe != null)
                returnMe.ImagePath = (await _imageRepository.GetAsync(incident.ImageId)).ImagePath;

            return returnMe;
        }

//        private async Task<IncidentDto> Map(Incident incidentToMap)
//        {
//            var imagePath = (await _imageRepository.GetAsync(incidentToMap.ImageId)).ImagePath;
//
//            return new
//        }
    }
}