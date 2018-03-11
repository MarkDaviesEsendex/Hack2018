using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Esendexers.HomelessWays.Models;
using Esendexers.HomelessWays.Services;
using Microsoft.AspNetCore.Mvc;

namespace Esendexers.HomelessWays.Web.Controllers
{
    public class ClustersController : HomelessWaysControllerBase
    {
        private readonly ClusterAppService _clusterAppService;

        public ClustersController(ClusterAppService clusterAppService)
        {
            _clusterAppService = clusterAppService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<IncidentCluster>), 200)]
        public async Task<IActionResult> GetAllIncidentClusters()
        {
            var clusters = await _clusterAppService.FindAllClusters();

            return Ok(clusters);
        }
    }
}
