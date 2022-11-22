using System.ComponentModel.DataAnnotations;

namespace Dtos_With_AutoMappers.Dtos
{
    public class PrescriptionCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string PatientName { get; set; }

        [Required(ErrorMessage = "Amount is Required")]

        public decimal Amount { get; set; }

        [Required]
        public int Frequency { get; set; }
    }
}
