using Microsoft.AspNetCore.Mvc;
using AreyesAssessment.API.Services.Interfaces;
using AreyesAssessment.API.DTOs;
using AreyesAssessment.Data.Filters;

namespace AreyesAssessment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChangelogController : ControllerBase
    {
        private readonly IChangelogService _changelogService;

        public ChangelogController(IChangelogService changelogService)
        {
            _changelogService = changelogService;
        }

        // GET: api/Changelog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChangelogDto>>> GetAll()
        {
            var changelogs = await _changelogService.GetAllAsync();
            return Ok(changelogs);
        }

        // GET: api/Changelog/filtered
        [HttpGet("filtered")]
        public async Task<ActionResult<IEnumerable<ChangelogDto>>> GetFiltered(
            [FromQuery] DateTime? minDate,
            [FromQuery] DateTime? maxDate,
            [FromQuery] string? description)
        {
            var filter = new ChangelogFilter
            {
                MinDate = minDate,
                MaxDate = maxDate,
                Description = description
            };

            var filteredChangelogs = await _changelogService.GetFilteredAsync(filter);
            return Ok(filteredChangelogs);
        }
    }
}
