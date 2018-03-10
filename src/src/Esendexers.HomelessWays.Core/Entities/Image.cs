using System;
using Abp.Domain.Entities;

namespace Esendexers.HomelessWays.Entities
{
    public class Image : Entity<Guid>
    {
        public string ImagePath { get; set; }
    }
}
