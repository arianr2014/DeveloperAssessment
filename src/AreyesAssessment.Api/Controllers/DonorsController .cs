using AreyesAssessment.API.Services.Interfaces;
using AreyesAssessment.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AreyesAssessment.Data.Filters;

namespace AreyesAssessment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorsController : ControllerBase
    {
        private readonly IDonorService _donorService;

        public DonorsController(IDonorService donorService)
        {
            _donorService = donorService;
        }

        // GET: api/Donors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DonorDto>>> GetAll()
        {
            var donors = await _donorService.GetAllAsync();
            return Ok(donors);
        }

        // GET: api/Donor/filtered
        [HttpGet("filtered")]
        public async Task<ActionResult<IEnumerable<DonorDto>>> GetFiltered(
            [FromQuery] string? donorName,
            [FromQuery] string? address)
        {
            var filter = new DonorFilter
            {
                DonorName = donorName,
                Address = address
            };

            var filteredDonors = await _donorService.GetFilteredAsync(filter);
            return Ok(filteredDonors);
        }



        // GET: api/Donors/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<DonorDto>> GetById(int id)
        {
            var donor = await _donorService.GetByIdAsync(id);

            if (donor == null)
            {
                return NotFound();
            }

            return Ok(donor);
        }

        // POST: api/Donors
        [HttpPost]
        public async Task<ActionResult<DonorDto>> Create(DonorDto donorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdDonor = await _donorService.CreateAsync(donorDto);
            return CreatedAtAction(nameof(GetById), new { id = createdDonor.DonorID }, createdDonor);
        }


         // PUT: api/Payment/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DonorDto donorDto)
        {

            donorDto.DonorID= id; ;
            var updatedDonor = await _donorService.UpdateAsync(donorDto);

            if (updatedDonor == null)
            {
                return NotFound();
            }

            return Ok(updatedDonor);
        }

        // DELETE: api/Donors/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _donorService.DeleteAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
