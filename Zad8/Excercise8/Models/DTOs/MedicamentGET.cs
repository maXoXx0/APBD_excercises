namespace Excercise8.Models.DTOs
{
    public class MedicamentGET
    {
        public int IdMedicament { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Type { get; set; } = null!;
    }
}
