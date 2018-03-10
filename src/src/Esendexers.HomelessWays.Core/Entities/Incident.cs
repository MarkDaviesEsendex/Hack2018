using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace Esendexers.HomelessWays.Entities
{
    public class Incident : Entity<uint>
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime Time { get; set; }
        public string Description { get; set; }
        public float PositivitySentimentScore { get; set; }
        [ForeignKey("ImageId")]
        public Guid ImageId { get; set; }
    }
}
