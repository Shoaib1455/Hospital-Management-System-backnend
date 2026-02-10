using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Domain.Entities
{
    public class Bed
    {
        public int BedId { get; set; }
        public string BedNumber { get; set; }
        public string BedType { get; set; }
        public string Status { get; set; }

        // Foreign keys
        public int WardId { get; set; }
        public Ward Wards { get; set; }

        public int? PatientId { get; set; }
        public Patient Patient { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
