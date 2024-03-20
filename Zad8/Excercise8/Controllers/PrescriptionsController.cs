using Excercise8.Services;
using Microsoft.AspNetCore.Mvc;

namespace Excercise8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionsController : ControllerBase
    {
        private readonly IPrescriptionsService _prescriptionsService;
        public PrescriptionsController(IPrescriptionsService prescriptionsService)
        {
            _prescriptionsService = prescriptionsService;
        }

        [HttpGet]
        
        public async Task<IActionResult> GetPrescription(int IdPrescrption) 
        {
            if (!_prescriptionsService.CheckIfPrescriptionExists(IdPrescrption))
            {
                return BadRequest("Taka recepta nie istnieje");
            }

            var res = await _prescriptionsService.GetPrescription(IdPrescrption);

            return Ok(res);
        }

        
    }
}
