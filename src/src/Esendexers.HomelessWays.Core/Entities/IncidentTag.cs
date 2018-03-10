using System.ComponentModel.DataAnnotations.Schema;

namespace Esendexers.HomelessWays.Entities
{
    public class IncidentTag
    {
        [ForeignKey("IncidentId")]
        public uint IncidentId { get; set; }
        [ForeignKey("TagId")]
        public uint TagId { get; set; }
    }
}
