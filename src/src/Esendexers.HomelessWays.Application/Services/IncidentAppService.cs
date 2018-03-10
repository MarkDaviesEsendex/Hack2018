using System.ComponentModel.DataAnnotations.Schema;
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

        private readonly IObjectMapper _objectMapper;

        public IncidentAppService(ILanguageAnalysysService languageAnalysys, IRepository<Incident> incidentRepository, IObjectMapper objectMapper)
        {
            _languageAnalysys = languageAnalysys;
            _incidentRepository = incidentRepository;
            _objectMapper = objectMapper;
        }

        public bool RecordNewIncident(CreateIncidentInput incidentRequest)
        {
            var incident = _objectMapper.Map<Incident>(incidentRequest);
            incident.PositivitySentimentScore = _languageAnalysys.GetSentimentScore(incident.Description);
            


            return true;
        }
    }
}