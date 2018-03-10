using System;
using Abp.AutoMapper;
using Esendexers.HomelessWays.Entities;

namespace Esendexers.HomelessWays.Inputs
{
    [AutoMapTo(typeof(Incident))]
    public class CreateIncidentInput
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Time { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
    }
}