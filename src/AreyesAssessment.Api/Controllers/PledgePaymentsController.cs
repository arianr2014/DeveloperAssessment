using Microsoft.AspNetCore.Mvc;
using AreyesAssessment.API.Services.Interfaces;
using AreyesAssessment.API.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using AreyesAssessment.Api.DTOs;

namespace AreyesAssessment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PledgePaymentController : ControllerBase
    {
        private readonly IPledgePaymentService _pledgePaymentService;

        public PledgePaymentController(IPledgePaymentService pledgePaymentService)
        {
            _pledgePaymentService = pledgePaymentService;
        }

        // GET: api/PledgePayment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PledgePaymentDto>>> GetAll()
        {
            var pledgePayments = await _pledgePaymentService.GetAllAsync();
            return Ok(pledgePayments);
        }

        // GET: api/PledgePayment/{pledgeId}/{paymentId}
        [HttpGet("{pledgeId:int}/{paymentId:int}")]
        public async Task<ActionResult<PledgePaymentDto>> GetById(int pledgeId, int paymentId)
        {
            var pledgePayment = await _pledgePaymentService.GetByIdAsync(pledgeId, paymentId);
            if (pledgePayment == null)
            {
                return NotFound();
            }
            return Ok(pledgePayment);
        }

        // POST: api/PledgePayment
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] PledgePaymentDto pledgePaymentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _pledgePaymentService.AddAsync(pledgePaymentDto);
            return CreatedAtAction(nameof(GetById), new { pledgeId = pledgePaymentDto.PledgeID, paymentId = pledgePaymentDto.PaymentID }, pledgePaymentDto);
        }



        // DELETE: api/PledgePayment/{pledgeId}/{paymentId}
        [HttpDelete("{pledgeId:int}/{paymentId:int}")]
        public async Task<IActionResult> Delete(int pledgeId, int paymentId)
        {
            var pledgePayment = await _pledgePaymentService.GetByIdAsync(pledgeId, paymentId);
            if (pledgePayment == null)
            {
                return NotFound();
            }
            await _pledgePaymentService.RemoveAsync(pledgeId, paymentId);
            return NoContent();
        }

        // GET: api/PledgePayment/byPledge/{pledgeId}
        [HttpGet("byPledge/{pledgeId}")]
        public async Task<ActionResult<IEnumerable<PledgePaymentDto>>> GetByPledgeId(int pledgeId)
        {
            var pledgePayments = await _pledgePaymentService.GetByPledgeIdAsync(pledgeId);
            return Ok(pledgePayments);
        }

        // GET: api/PledgePayment/byPayment/{paymentId}
        [HttpGet("byPayment/{paymentId}")]
        public async Task<ActionResult<IEnumerable<PledgePaymentDto>>> GetByPaymentId(int paymentId)
        {
            var pledgePayments = await _pledgePaymentService.GetByPaymentIdAsync(paymentId);
            return Ok(pledgePayments);
        }
    }
}
