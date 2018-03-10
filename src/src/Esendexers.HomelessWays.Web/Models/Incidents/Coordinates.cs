﻿using Abp.AutoMapper;

namespace Esendexers.HomelessWays.Web.Models.Incidents
{
    [AutoMapTo(typeof(HomelessWays.Models.Coordinates))]
    public class Coordinates
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}