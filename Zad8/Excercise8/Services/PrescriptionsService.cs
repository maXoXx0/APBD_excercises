using Excercise8.Data;
using Excercise8.Models.DTOs;

namespace Excercise8.Services
{
    public interface IPrescriptionsService
    { 
        bool CheckIfPrescriptionExists(int prescriptionId);
        Task<PrescriptionWithAllData> GetPrescription(int prescriptionId);
    }

    public class PrescriptionsService : IPrescriptionsService
    {
        
        private readonly MedicamentsContext _context;
        public PrescriptionsService(MedicamentsContext context)
        {
            _context = context;
        }

        public bool CheckIfPrescriptionExists(int prescriptionId)
        {
            var res = _context.Prescriptions.Any(e => e.IdPrescription == prescriptionId);
            return res;
        }

        public async Task<PrescriptionWithAllData> GetPrescription(int prescriptionId)
        {
            var prescription = _context.Prescriptions.FirstOrDefault(e => e.IdPrescription.Equals(prescriptionId));
            var doctor = _context.Doctors.FirstOrDefault(e => e.IdDoctor == prescription.IdDoctor);
            var patient = _context.Patients.FirstOrDefault(e => e.IdPatient == prescription.IdPatient);
            var medsIds = _context.PrescriptionsMedicaments.Where(e => e.IdPrescription == prescriptionId).Select(e => e.IdMedicament).ToList();

            List<MedicamentGET> medsList = new List<MedicamentGET>();
            foreach (var m in medsIds)
            {
                var med = _context.Medicaments.FirstOrDefault(e => e.IdMedicament == m);
                medsList.Add(new MedicamentGET
                {
                    IdMedicament = med.IdMedicament,
                    Name = med.Name,
                    Description = med.Description,
                    Type = med.Type
                });
            }


            return new PrescriptionWithAllData
            {
                IdPrescription = Convert.ToInt32(prescription.IdPrescription),
                Date = prescription.Date,
                DueDate = prescription.DueDate,
                Doctor = new DoctorGET
                {
                    IdDoctor = doctor.IdDoctor,
                    FirstName = doctor.FirstName,
                    LastName = doctor.LastName,
                    Email = doctor.Email,
                },
                Patient = new PatientGET
                {
                    IdPatient = patient.IdPatient,
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    Birthdate = patient.Birthdate
                },
                Medicaments = medsList
            };
        }
    }
}
