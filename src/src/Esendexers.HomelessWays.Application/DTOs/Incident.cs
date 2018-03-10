using System;
using Abp.AutoMapper;
using Esendexers.HomelessWays.Entities;

namespace Esendexers.HomelessWays.DTOs
{
    [AutoMapFrom(typeof(Incident))]
    [AutoMapTo(typeof(Incident))]
    public class IncidentDto
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime Time { get; set; }
        public string Description { get; set; }
        public double PositivitySentimentScore { get; set; }
        public byte[] Image { get; set; }
    }
}
