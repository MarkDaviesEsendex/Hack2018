using Abp.AutoMapper;

namespace Esendexers.HomelessWays.Web.Models.Incidents
{
    [AutoMapTo(typeof(HomelessWays.Models.Coordinates))]
    public class Coordinates
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}