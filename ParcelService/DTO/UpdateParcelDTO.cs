using System.ComponentModel.DataAnnotations;

namespace ParcelService.DTO
{
    public class UpdateParcelDTO
    {
        [Required]
        [StringLength(100)]
        public string Status { get; set; }
    }
}
