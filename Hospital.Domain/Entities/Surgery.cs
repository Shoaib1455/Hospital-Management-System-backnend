using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Domain.Entities
{
    public class Surgery
    {
        [Key]
        public int SurgeryId { get; set; }

        [Required]
        [MaxLength(100)]
        public string SurgeryName { get; set; }  // e.g., Appendectomy, Heart Bypass

        [Required]
        public DateTime SurgeryDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string SurgeryType { get; set; }  // e.g., Elective, Emergency

        [Required]
        public int PatientId { get; set; }

        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }

        public int? DoctorId { get; set; } // Optional if doctor not assigned yet

        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }

        [MaxLength(500)]
        public string Notes { get; set; }

        public bool IsCompleted { get; set; } = false;
    }
}
