using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using AutoMapper.Configuration.Conventions;
using Esendexers.HomelessWays.Entities;
using Esendexers.HomelessWays.Inputs;

namespace Esendexers.HomelessWays.Services
{
    public interface IIncidentAppService
    {
        bool RecordNewIncident(CreateIncidentInput incidentRequest);
    }

    public class IncidentAppService : HomelessWaysAppServiceBase, IIncidentAppService
    {
        private readonly ILanguageAnalysysService _languageAnalysys;
        private readonly IRepository<Incident> _incidentRepository;
        private readonly IRepository<Image> _imageRepository;
        private readonly IRepository<Tag> _tagRepository;
        private readonly IRepository<IncidentTag> _incidentTagRepository;

        private readonly IObjectMapper _objectMapper;

        public IncidentAppService(ILanguageAnalysysService languageAnalysys, IRepository<Incident> incidentRepository, IObjectMapper objectMapper, IRepository<Tag> tagRepository, IRepository<IncidentTag> incidentTagRepository, IRepository<Image> imageRepository)
        {
            _languageAnalysys = languageAnalysys;
            _incidentRepository = incidentRepository;
            _objectMapper = objectMapper;
            _tagRepository = tagRepository;
            _incidentTagRepository = incidentTagRepository;
            _imageRepository = imageRepository;
        }

        public bool RecordNewIncident(CreateIncidentInput incidentRequest)
        {
            var incident = _objectMapper.Map<Incident>(incidentRequest);
            incident.PositivitySentimentScore = _languageAnalysys.GetSentimentScore(incident.Description);

            var phrases = _languageAnalysys.GetKeyPrases(incident.Description);
            var incidentTags = (from phrase in phrases
                let databasePhrase = _tagRepository.GetAll().FirstOrDefault(tag => tag.Name == phrase)
                select databasePhrase == null
                    ? _tagRepository.Insert(new Tag {Name = phrase})
                    : databasePhrase).ToList();
            var image = _imageRepository.Insert(new Image { });
            incident.ImageId = image.Id;

            incident = _incidentRepository.Insert(incident);

            foreach (var incidentTag in incidentTags)
            {
                _incidentTagRepository.Insert(new IncidentTag{IncidentId = incident.Id, TagId = incidentTag.Id});
            }
            return true;
        }
    }
}