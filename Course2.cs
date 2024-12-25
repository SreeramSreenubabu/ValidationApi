//using YourNamespace.Attributes;
using System.ComponentModel.DataAnnotations;

namespace YourNamespace.Models
{
    public class Course2
    {
        [Required]
        [MaxLength(50)]
        public string courseId { get; set; }

        [Required]
        public DateTime updatedDate { get; set; }

        [Required]
        [MaxLength(20)]
        public string status { get; set; }
    }
}
