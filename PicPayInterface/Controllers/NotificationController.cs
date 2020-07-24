using Microsoft.AspNetCore.Mvc;
using PicPay;
using PicPay.Models;
using System;
using System.Threading.Tasks;

namespace PicPayInterface
{
    [ApiController]
    [Route("notification")]
    public class NotificationController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(NotificationRequest body, string url)
        {
            try
            {   
                var result = await new NotificationService().Create(body, url);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}