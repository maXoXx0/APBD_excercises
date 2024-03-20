using Excercise8.Models.DTOs;
using Excercise8.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Excercise8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorsService _doctorsService;
        public DoctorsController(IDoctorsService doctorsService)
        {
            _doctorsService = doctorsService;
        }
        [Authorize]
        [HttpGet]
        [Route("{idDoctor}")]
        public async Task<IActionResult> GetDoctor(int idDoctor)
        {
            var res = _doctorsService.GetDoctor(idDoctor).Result;

            return Ok(res);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostDoctor(DoctorPOST doctor)
        {
            if (_doctorsService.DoesThisDoctorExists(doctor))
            {
                return BadRequest($"Doktor {doctor.FirstName} {doctor.LastName} juz istnieje");
            }

            await _doctorsService.AddDocotor(doctor);

            return Created("Dodano", doctor);
        }
        [Authorize]
        [HttpPut]
        [Route("{IdDoctor}")]
        public async Task<IActionResult> PutDoctor(int idDoctor, DoctorPUT doctor) 
        {
            if (!_doctorsService.DoesDoctorWithTihisIdExists(idDoctor))
            {
                return BadRequest($"Nie isntieje doktor od id: {idDoctor}");
            }

            await _doctorsService.ChangeDoctor(idDoctor, doctor);

            return Ok("Dokonano zmian");
        }
        [Authorize]
        [HttpDelete]
        [Route("{idDoctor}")]
        public async Task<IActionResult> DeleteDoctor(int idDoctor)
        {
            if (!_doctorsService.DoesDoctorWithTihisIdExists(idDoctor))
            {
                return BadRequest($"Nie isntieje doktor od id: {idDoctor}");
            }

            await _doctorsService.DeleteDoctor(idDoctor);

            return Ok("Usunięto");
        }



    }
}
