namespace Excercise8.Models.DTOs
{
    public class PrescriptionWithAllData
    {
        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public  DoctorGET Doctor { get; set; }
        public  PatientGET Patient { get; set; }
        public ICollection<MedicamentGET> Medicaments { get; set; } = new List<MedicamentGET>();
    }
}
