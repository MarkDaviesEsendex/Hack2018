using Microsoft.AspNetCore.Http;

namespace Esendexers.HomelessWays.Web.Models.Incidents
{
    public class IncidentViewModel
    {
        public string Description { get; set; }
        public IFormFile File { get; set; }
    }
}