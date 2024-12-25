using YourNamespace.Attributes;
using System;

namespace YourNamespace.Models
{
    public class Course
    {
        [Required]
        [MaxLength(50)]
        public string requestedID { get; set; }

        [Required]
        public DateTime requestedDate { get; set; }

        [Required]
        public int totalRow { get; set; }
    }
}
