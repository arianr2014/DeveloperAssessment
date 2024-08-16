using Microsoft.AspNetCore.Mvc;
using AreyesAssessment.API.Services.Interfaces;
using AreyesAssessment.API.DTOs;
using AreyesAssessment.Data.Filters;

namespace AreyesAssessment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PledgeController : ControllerBase
    {
        private readonly IPledgeService _pledgeService;

        public PledgeController(IPledgeService pledgeService)
        {
            _pledgeService = pledgeService;
        }

        // GET: api/Pledge
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PledgeDto>>> GetAll()
        {
            var pledges = await _pledgeService.GetAllAsync();
            return Ok(pledges);
        }

        // GET: api/Pledge/filtered
        [HttpGet("filtered")]
        public async Task<ActionResult<IEnumerable<PledgeDto>>> GetFiltered(
            [FromQuery] DateTime? minPledgeDate,
            [FromQuery] DateTime? maxPledgeDate,
            [FromQuery] decimal? minPledgeAmount,
            [FromQuery] decimal? maxPledgeAmount)
        {
            var filter = new PledgeFilter
            {
                MinPledgeDate = minPledgeDate,
                MaxPledgeDate = maxPledgeDate,
                MinPledgeAmount = minPledgeAmount,
                MaxPledgeAmount = maxPledgeAmount
            };

            var filteredPledges = await _pledgeService.GetFilteredAsync(filter);
            return Ok(filteredPledges);
        }


        // GET: api/Pledge/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PledgeDto>> GetById(int id)
        {
            var pledge = await _pledgeService.GetByIdAsync(id);
            if (pledge == null)
            {
                return NotFound();
            }
            return Ok(pledge);
        }

        // POST: api/Pledge
        [HttpPost]
        public async Task<ActionResult<PledgeDto>> Create(PledgeDto pledgeDto)
        {
            var createdPledge = await _pledgeService.CreateAsync(pledgeDto);
            return CreatedAtAction(nameof(GetById), new { id = createdPledge.PledgeID }, createdPledge);
        }

        // PUT: api/Pledge/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PledgeDto pledgeDto)
        {

            pledgeDto.PledgeID = id;
            var updated = await _pledgeService.UpdateAsync(pledgeDto);
            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Pledge/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _pledgeService.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
