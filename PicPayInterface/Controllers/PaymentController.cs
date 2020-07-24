using Microsoft.AspNetCore.Mvc;
using PicPay;
using PicPay.Models;
using System;
using System.Threading.Tasks;

namespace PicPayInterface
{
    [ApiController]
    [Route("payment")]
    public class PaymentController : ControllerBase
    {
        public PaymentService PaymentService { get => new PaymentService(); }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]PaymentRequest body)
        {
            try
            {
                var result = await PaymentService.Create(body);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost("{referenceId}/cancel")]
        public async Task<IActionResult> Cancel([FromBody]PaymentRequest body, string referenceId)
        {
            try
            {
                var result = await PaymentService.Cancel(body, referenceId);
                return Ok(result);
            }
            catch (Exception ex)
            {
              return BadRequest(ex);   
            }
        }
        [HttpGet("{referenceId}", Name = "Status")]
        public async Task<IActionResult> Status(string referenceId)
        {
            try
            {
                var result = await PaymentService.Status(referenceId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}