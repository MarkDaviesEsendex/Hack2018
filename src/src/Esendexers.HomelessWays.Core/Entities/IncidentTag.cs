using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace Esendexers.HomelessWays.Entities
{
    public class IncidentTag : Entity
    {
        [ForeignKey("IncidentId")]
        public int IncidentId { get; set; }
        [ForeignKey("TagId")]
        public int TagId { get; set; }
    }
}
