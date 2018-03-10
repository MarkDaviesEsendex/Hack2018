using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.ObjectMapping;
using Esendexers.HomelessWays.DTOs;
using Esendexers.HomelessWays.Entities;
using Esendexers.HomelessWays.Models;
using GeoCoordinatePortable;

namespace Esendexers.HomelessWays.Services
{
    public interface IIncidentService
    {
        Task<IEnumerable<IncidentDto>> GetIncidentsAroundLocation(Coordinates currentLocation, uint radius);
    }

    public class IncidentService : IIncidentService
    {
        private readonly IRepository<Incident> _incidentRepository;
        private readonly IObjectMapper _objectMapper;

        public IncidentService(IRepository<Incident> incidentRepository, IObjectMapper objectMapper)
        {
            _incidentRepository = incidentRepository;
            _objectMapper = objectMapper;
        }

        public async Task<IEnumerable<IncidentDto>> GetIncidentsAroundLocation(Coordinates currentLocation, uint radius)
        {
            var currentCoordinate = new GeoCoordinate(double.Parse(currentLocation.Latitude), double.Parse(currentLocation.Longitude));

            var incidents = await _incidentRepository.GetAllListAsync();

            return incidents.ToList()
                .Select(i => Map(i, radius, currentCoordinate))
                .Where(i => i != null)
                .ToList();
        }

        private IncidentDto Map(Incident incident, uint radius, GeoCoordinate currentCoordinate)
        {
            var incidentCoordinate = new GeoCoordinate(double.Parse(incident.Latitude), double.Parse(incident.Longitude));

            return currentCoordinate.GetDistanceTo(incidentCoordinate) < radius ? _objectMapper.Map<IncidentDto>(incident) : null;
        }
    }
}