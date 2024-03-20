using Excercise8.Data;
using Excercise8.Models;
using Excercise8.Models.DTOs;

namespace Excercise8.Services
{
    public interface IDoctorsService
    {
        Task<DoctorGET> GetDoctor(int id);
        bool DoesThisDoctorExists(DoctorPOST doctor);
        Task AddDocotor(DoctorPOST doctor);
        bool DoesDoctorWithTihisIdExists(int IdDoctor);
        Task ChangeDoctor(int idDoctor, DoctorPUT doctor);
        Task DeleteDoctor(int idDoctor);
    }
    public class DoctorsService : IDoctorsService
    {
        private readonly MedicamentsContext _context;
        public DoctorsService(MedicamentsContext context)
        {
            _context = context;
        }

        public async Task AddDocotor(DoctorPOST doctor)
        {
            await _context.Doctors.AddAsync(new Doctor
            {
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Email = doctor.Email
            });
            await _context.SaveChangesAsync();
        }

        public async Task ChangeDoctor(int idDoctor, DoctorPUT doctor)
        {
            var doc = _context.Doctors.FirstOrDefault(e => e.IdDoctor == idDoctor);

            doc.FirstName = doctor.FirstName;
            doc.LastName = doctor.LastName;
            doc.Email = doctor.Email;

            await _context.SaveChangesAsync();

        }

        public async Task DeleteDoctor(int idDoctor)
        {
            var doc = _context.Doctors.FirstOrDefault(e => e.IdDoctor == idDoctor);
            _context.Doctors.Remove(doc);
            await _context.SaveChangesAsync();
        }

        public bool DoesDoctorWithTihisIdExists(int IdDoctor)
        {
            var res = _context.Doctors.Where(e => e.IdDoctor == IdDoctor).Any();

            return res;
        }

        public bool DoesThisDoctorExists(DoctorPOST doctor)
        {
            var res = _context.Doctors.Where(e => e.FirstName == doctor.FirstName && e.LastName == doctor.LastName).Any();

            return res;
        }

        public async Task<DoctorGET> GetDoctor(int id)
        {
            var res = _context.Doctors.Where(e => e.IdDoctor == id).FirstOrDefault();
            var doc = new DoctorGET
            {
                IdDoctor = res.IdDoctor,
                FirstName = res.FirstName,
                LastName = res.LastName,
                Email = res.Email
            };


            return doc;
        }
    }
}
