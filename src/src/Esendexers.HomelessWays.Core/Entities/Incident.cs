using System;
using Abp.Domain.Entities;

namespace Esendexers.HomelessWays.Entities
{
    public class Incident : Entity
    {
        public virtual string Latitude { get; set; }
        public virtual string Longitude { get; set; }
        public virtual DateTime Time { get; set; }
        public virtual string Description { get; set; }
        public virtual double PositivitySentimentScore { get; set; }
        public virtual Guid ImageId { get; set; }
    }
}
