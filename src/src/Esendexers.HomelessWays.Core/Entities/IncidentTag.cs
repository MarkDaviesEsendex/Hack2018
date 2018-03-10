using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace Esendexers.HomelessWays.Entities
{
    public class IncidentTag : Entity
    {
        public virtual int IncidentId { get; set; }
        public virtual int TagId { get; set; }
    }
}
