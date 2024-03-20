using Exercise4.Models;
using Exercise4.Models.DTOs;
using Exercise4.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;

namespace Exercise4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly string _connectionString;
        private readonly IAnimalsRepository _animalsRepository;

        public AnimalsController(IAnimalsRepository animalsRepository)
        {
            _animalsRepository = animalsRepository;
        }

        
        

        [HttpGet]
        public async Task<IActionResult> GetAnimals(string? orderBy)
        {
            if (orderBy is null) orderBy = "name";

         
            var animals = await _animalsRepository.GetAnimalsAsync(orderBy);

            
            return Ok(animals);
        }

        [HttpPost]
        public async Task<IActionResult> AddAnimal(AnimalPost newAnimal)
        {
            
            var animal = new Animal{
                Id = newAnimal.Id,
                Name = newAnimal.Name,
                Description = newAnimal.Description,
                Category = newAnimal.Category,
                Area = newAnimal.Area
            };

            if (newAnimal != null)
            {

            }

            ;

            if (await _animalsRepository.CheckQuearyAsync(animal.Id))
            {
                return Conflict("Zwierze o takim ID już istnieje");
            }
            else
            {
                await _animalsRepository.AddAnimal(animal);
            }



            return Created("Stworzono nowe zwierze", animal);
        }

        [HttpPut("{animalID}")]
        public async Task<IActionResult> Put(int animalID, AnimalPUT newAnimalData)
        {
            var animal = new Animal
            {
                Id = animalID,
                Name = newAnimalData.Name,
                Description = newAnimalData.Description,
                Category = newAnimalData.Category,
                Area = newAnimalData.Area
            };

            if (await _animalsRepository.CheckQuearyAsync(animal.Id))
            {
                await _animalsRepository.UpdateAnimal(animal);
            }
            else
            {
                return NotFound("Zwierze o takim ID nie istnieje");
            }


            return Ok(animal);
        }

        [HttpDelete("{animalID}")]
        public async Task<IActionResult> Delete(int animalID)
        {
            if (await _animalsRepository.CheckQuearyAsync(animalID))
            {
                await _animalsRepository.DeleteAnimal(animalID);
            }
            else
            {
                return NotFound("Zwierze o takim ID nie istnieje");
            }
            return Ok($"Pomyślnie usunięto zwierze od ID : {animalID}.");
        }
    }
}
