using System.ComponentModel.DataAnnotations;

namespace ParcelService.DTO
{
    public class CreateParcelDTO
    {
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string TrackingNumber { get; set; }

        [Required]
        public int Sender { get; set; }
        [Required]
        public string Origin { get; set; }
        [Required]
        public string Destination { get; set; }

        [Required]
        public string Receiver { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
