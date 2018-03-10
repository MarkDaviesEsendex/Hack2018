using Microsoft.AspNetCore.Http;

namespace Esendexers.HomelessWays.Web.Models.Submit
{
    public class IncidentModel
    {
        public string Image { get; set; }
        public Node Position { get; set; }
        public string Description { get; set; }
    }
}