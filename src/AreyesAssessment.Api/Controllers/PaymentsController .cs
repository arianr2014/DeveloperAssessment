using Microsoft.AspNetCore.Mvc;
using AreyesAssessment.API.Services.Interfaces;
using AreyesAssessment.API.DTOs;
using AreyesAssessment.Data.Filters;

namespace AreyesAssessment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        // GET: api/Payment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDto>>> GetAll()
        {
            var payments = await _paymentService.GetAllAsync();
            return Ok(payments);
        }

        // GET: api/Payment/filtered
        [HttpGet("filtered")]
        public async Task<ActionResult<IEnumerable<PaymentDto>>> GetFiltered(
            [FromQuery] DateTime? minPaymentDate,
            [FromQuery] DateTime? maxPaymentDate,
            [FromQuery] decimal? minPaymentAmount,
            [FromQuery] decimal? maxPaymentAmount)
        {
            var filter = new PaymentFilter
            {
                MinPaymentDate = minPaymentDate,
                MaxPaymentDate = maxPaymentDate,
                MinPaymentAmount = minPaymentAmount,
                MaxPaymentAmount = maxPaymentAmount
            };

            var filteredPayments = await _paymentService.GetFilteredAsync(filter);
            return Ok(filteredPayments);
        }


        // GET: api/Payment/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDto>> GetById(int id)
        {
            var payment = await _paymentService.GetByIdAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            return Ok(payment);
        }

        // POST: api/Payment
        [HttpPost]
        public async Task<ActionResult<PaymentDto>> Create(PaymentDto paymentDto)
        {
            var createdPayment = await _paymentService.CreateAsync(paymentDto);
            return CreatedAtAction(nameof(GetById), new { id = createdPayment.PaymentID }, createdPayment);
        }

        // PUT: api/Payment/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PaymentDto paymentDto)
        {
            paymentDto.PaymentID = id;
             var updated = await _paymentService.UpdateAsync(paymentDto);
            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Payment/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _paymentService.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
