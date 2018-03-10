using Microsoft.AspNetCore.Http;

namespace Esendexers.HomelessWays.Web.Models.Submit
{
    public class IncidentModel
    {
        public IFormFile IncidentImage { get; set; }
        public string Latitude { get;set; }
        public string Longitude { get; set; }
        public string Description { get; set; }
    }
}