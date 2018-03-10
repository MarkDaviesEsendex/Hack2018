using System;
using System.IO;
using Abp.AutoMapper;
using Esendexers.HomelessWays.Entities;

namespace Esendexers.HomelessWays.Inputs
{
    [AutoMapTo(typeof(Incident))]
    public class CreateIncidentInput
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime Time { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
    }
}