using Excercise7.Data;
using Excercise7.Models;
using Excercise7.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace Excercise7.Services
{

    public interface ITripsService
    {
        Task<IEnumerable<Trip>> GetTrips();
        Task<IEnumerable<TripWithAdditionalData>> GetTrips2();
        bool DoesClientHaveTrips(int idClient);
        Task DeleteClient(int idClient);
        Task DoesClientExists(ClientPOST client);
        bool IsClientEnroledOnGivenTrip(ClientPOST client);
        bool DoesTripExisist(int tripId, string tripName);
        Task EnrollClientOnGivenTrip(ClientPOST client);
        
    }

    public class TripsService : ITripsService
    {

        private readonly Excercise7dbContext _context;
    
        public TripsService(Excercise7dbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Trip>> GetTrips()
        {
            return await _context.Trips
                .Include(e => e.IdCountries)
                .Include(e => e.ClientTrips)
                .ThenInclude(e => e.IdClientNavigation)
                .ToListAsync();
        }

        public async Task<IEnumerable<TripWithAdditionalData>> GetTrips2()
        {
            return await _context.Trips.Select(e => new TripWithAdditionalData
            {
                Name = e.Name,
                Description = e.Description,
                DateFrom = e.DateFrom,
                DateTo = e.DateTo,
                MaxPeople = e.MaxPeople,
                Countries = e.IdCountries.Select(c => new CountryName
                {
                    Name = c.Name
                }),
                    Clients = e.ClientTrips.Select(c => new ClientName { 
                    FirstName = c.IdClientNavigation.FirstName,
                    LastName = c.IdClientNavigation.LastName
                })

            })
             .OrderByDescending(e => e.DateFrom)
             .ToListAsync();
        }

        public bool DoesClientHaveTrips(int idClient)
        {
            return _context.ClientTrips.Where(e => e.IdClient == idClient).Any();    
        }

        public async Task DeleteClient(int idClient)
        {

            var client = _context.Clients.Where(e => e.IdClient == idClient).FirstOrDefault();


            _context.Remove<Client>(client);
            await _context.SaveChangesAsync();
            
        }

        public async Task DoesClientExists(ClientPOST client)
        {
            if (!(_context.Clients.Where(e => e.Pesel == client.Pesel).Any()))
            {
                await _context.Clients.AddAsync(new Client
                {
                    FirstName = client.FirstName,
                    LastName = client.LastName,
                    Email = client.Email,
                    Telephone = client.Telephone,
                    Pesel = client.Pesel
                });
                await _context.SaveChangesAsync();
                
            }
        }

        public bool IsClientEnroledOnGivenTrip(ClientPOST client)
        {
            var cl = _context.Clients.Where(e => e.Pesel == client.Pesel).SingleOrDefault();

            return _context.ClientTrips.Any(e => e.IdTrip.Equals(client.TripID) && e.IdClient.Equals(cl.IdClient));
        }

        public bool DoesTripExisist(int tripId, string tripName)
        {
            return _context.Trips.Where(e => e.IdTrip == tripId && e.Name == tripName).Any();
        }

        public async Task EnrollClientOnGivenTrip(ClientPOST client)
        {
            var cl = _context.Clients.Where(e => e.Pesel == client.Pesel).SingleOrDefault();
            await _context.ClientTrips.AddAsync(new ClientTrip
            {
                IdClient = cl.IdClient,
                IdTrip = client.TripID,
                RegisteredAt = DateTime.UtcNow,
                PaymentDate = client.PaymentDay
            });
            await _context.SaveChangesAsync();
        }
    }
}

  