using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Domain.Entities
{
    public class Billing
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment PK
        public int Id { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; } // Link to Patient

        [Column(TypeName = "decimal(10,2)")] // PostgreSQL compatible
        public decimal Amount { get; set; }

        public DateTime BillingDate { get; set; } = DateTime.UtcNow;

        [Required]
        [MaxLength(20)]
        public string Status { get; set; } = "Pending"; // Pending, Paid, Cancelled

        // Navigation property
        public Patient Patient { get; set; } = null!;

    }
}
