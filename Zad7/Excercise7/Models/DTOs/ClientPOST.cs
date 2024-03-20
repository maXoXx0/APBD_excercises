using System.ComponentModel.DataAnnotations;

namespace Excercise7.Models.DTOs
{
    public class ClientPOST
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Telephone { get; set; }
        [Required]
        [MaxLength(11)]
        public string Pesel { get; set; }
        [Required]
        public int TripID { get; set; }
        [Required]
        public string TripName { get; set;}
        [Required]
        public DateTime PaymentDay { get; set;}
    }
}
