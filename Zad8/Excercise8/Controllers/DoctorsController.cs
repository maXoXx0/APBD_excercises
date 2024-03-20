using Excercise8.Models.DTOs;
using Excercise8.Services;
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

        [HttpGet]
        [Route("{idDoctor}")]
        public async Task<IActionResult> GetDoctor(int idDoctor)
        {
            var res = _doctorsService.GetDoctor(idDoctor).Result;

            return Ok(res);
        }

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
