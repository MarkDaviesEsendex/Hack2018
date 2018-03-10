using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace Esendexers.HomelessWays.Entities
{
    public class IncidentTag : Entity
    {
        [ForeignKey("IncidentId")]
        public virtual int IncidentId { get; set; }
        [ForeignKey("TagId")]
        public virtual int TagId { get; set; }
    }
}
