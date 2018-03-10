using System;
using Abp.AutoMapper;
using Esendexers.HomelessWays.Entities;

namespace Esendexers.HomelessWays.DTOs
{
    [AutoMapFrom(typeof(Incident))]
    [AutoMapTo(typeof(Incident))]
    public class IncidentDto
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Time { get; set; }
        public string Description { get; set; }
        public double PositivitySentimentScore { get; set; }
        public string ImagePath { get; set; }
    }
}
