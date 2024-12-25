using System.ComponentModel.DataAnnotations;

namespace YourNamespace.Models
{
    public class Course3
    {
        [Required]
        [MaxLength(50)]
        public string ZipCode { get; set; }

        [Required]
        public DateTime PresentTime { get; set; }

        [MaxLength(10)]
        [Required]
        public required string Description { get; set; }
    }
}
