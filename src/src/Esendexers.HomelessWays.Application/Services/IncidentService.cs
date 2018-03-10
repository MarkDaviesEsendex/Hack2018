using System.Collections.Generic;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using Esendexers.HomelessWays.DTOs;
using Esendexers.HomelessWays.Entities;
using Esendexers.HomelessWays.Models;
using GeoCoordinatePortable;

namespace Esendexers.HomelessWays.Services
{
    public interface IIncidentService
    {
        IEnumerable<IncidentDto> GetIncidentsAroundLocation(Coordinates currentLocation, uint radius);
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

        public IEnumerable<IncidentDto> GetIncidentsAroundLocation(Coordinates currentLocation, uint radius)
        {
            var currentCoordinate = new GeoCoordinate(double.Parse(currentLocation.Latitude), double.Parse(currentLocation.Longitude));

            foreach (var incident in _incidentRepository.GetAll())
            {
                var incidentCoordinate = new GeoCoordinate(double.Parse(incident.Latitude), double.Parse(incident.Longitude));

                if (currentCoordinate.GetDistanceTo(incidentCoordinate) < radius)
                    yield return _objectMapper.Map<IncidentDto>(incident);
            }
        }
    }
}