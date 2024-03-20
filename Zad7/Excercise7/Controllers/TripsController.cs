using Excercise7.Data;
using Excercise7.Models.DTOs;
using Excercise7.Services;
using Microsoft.AspNetCore.Mvc;

namespace Excercise7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly ITripsService _tripsService;
        public TripsController(ITripsService tripsService)
        {
            _tripsService = tripsService;
        }
        [HttpGet]
        public async Task<IActionResult> GetTrips()
        {
            var trips = await _tripsService.GetTrips2();

            return Ok(trips);
        }
        [HttpPost]
        [Route("idTrip/clients")]
        public async Task<IActionResult> PostClient(ClientPOST client)
        {
            await _tripsService.DoesClientExists(client);

            if (_tripsService.IsClientEnroledOnGivenTrip(client))
            {
                return BadRequest($"Klient {client.FirstName} {client.LastName} jest już zapisany na wycieczke {client.TripName}");
            }

            if (!_tripsService.DoesTripExisist(client.TripID, client.TripName))
            {
                return BadRequest($"Klient {client.FirstName} {client.LastName} jest już zapisany na wycieczke {client.TripName}");
            }

            await _tripsService.EnrollClientOnGivenTrip(client);
            return Ok($"Zapisano {client.FirstName} {client.LastName} na wycieczkę {client.TripName}");
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ITripsService _tripsService;
        public ClientsController(ITripsService tripsService)
        {
            _tripsService = tripsService;
        }

        [HttpDelete]
        [Route("{idClient}")]
        public async Task<IActionResult> DeleteClient(int idClient)
        {
            if (_tripsService.DoesClientHaveTrips(idClient))
            {
                return BadRequest("Klient bierze udział w wycieczce. Nie można go usunąć");
            }

            await _tripsService.DeleteClient(idClient);

            return Ok($"Usunięto klienta o ID : {idClient}");
        }
    }

}
