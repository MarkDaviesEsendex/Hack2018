using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Esendexers.HomelessWays.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Esendexers.HomelessWays.Web.Controllers
{
    public class TagsController : HomelessWaysControllerBase
    {
        private readonly IRepository<Tag> _tagRepository;

        public TagsController(IRepository<Tag> tagRepository)
        {
            _tagRepository = tagRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTags() 
            => Ok(await _tagRepository.GetAllListAsync());
    }
}
