using System;
using Abp.Domain.Entities;

namespace Esendexers.HomelessWays.Entities
{
    public class Image : Entity<Guid>
    {
        public virtual string ImagePath { get; set; }
    }
}
