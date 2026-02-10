using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Domain.Entities
{
    public class Ward
    {
        [Key]
        public int WardId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }  // Ward name

        [Required]
        [MaxLength(50)]
        public string Type { get; set; }  // e.g., ICU, General

        [Required]
        [Range(0, 20)]
        public int Floor { get; set; }  // Floor number

        [Required]
        [Range(1, 100)]
        public int Capacity { get; set; }  // Number of beds

        [MaxLength(500)]
        public string Description { get; set; }  // Optional description

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Navigation property
        public ICollection<Bed> Beds { get; set; }
    }
}
