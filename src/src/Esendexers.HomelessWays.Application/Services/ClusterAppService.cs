using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using Esendexers.HomelessWays.DTOs;
using Esendexers.HomelessWays.Entities;
using Esendexers.HomelessWays.Models;

namespace Esendexers.HomelessWays.Services
{
    public interface IClusterAppService
    {
        Task<IEnumerable<IncidentCluster>> FindAllClusters();
    }

    public class ClusterAppService : IClusterAppService
    {
        private readonly IRepository<Incident> _incidentRepository;
        private readonly IObjectMapper _objectMapper;
        private readonly IIncidentAppService _incidentAppService;

        public ClusterAppService(IRepository<Incident> incidentRepository, IObjectMapper objectMapper, IIncidentAppService incidentAppService)
        {
            _incidentRepository = incidentRepository;
            _objectMapper = objectMapper;
            _incidentAppService = incidentAppService;
        }

        public async Task<IEnumerable<IncidentCluster>> FindAllClusters()
        {
            var incidentsToCluster = _objectMapper.Map<List<IncidentDto>>(await _incidentRepository.GetAllListAsync());
            var clusteredIncidents = new List<IncidentDto>();
            var incidentClusters = new List<IncidentCluster>();

            foreach (var incident in incidentsToCluster)
            {
                if (clusteredIncidents.Any(dto => dto.Id == incident.Id))
                    continue;

                var nearbyIncidents = (await _incidentAppService.GetIncidentsAroundLocation(incident.Latitude, incident.Longitude, 5000)).ToList();
                incidentClusters.Add(CreateCluster(nearbyIncidents));
                clusteredIncidents.AddRange(nearbyIncidents);
            }

            return incidentClusters;
        }

        private static IncidentCluster CreateCluster(IEnumerable<IncidentDto> nearbyIncidents)
        {
            var coordinates = nearbyIncidents.Select(nearbyIncident =>
                new Coordinates {Latitude = nearbyIncident.Latitude, Longitude = nearbyIncident.Longitude}).ToList();

            return new IncidentCluster
            {
                ClusterCoordinates = coordinates
            };
        }
    }
}