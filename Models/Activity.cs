using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace zohocrm3._0.Models
{
    public class Activity
    {
        [Key]
        public int Id { get; set; } // Unique identifier for the activity

        [Required]
        [StringLength(200)]
        public string ActivityName { get; set; } // Name or title of the activity

        [StringLength(500)]
        public string Description { get; set; } // Description or details of the activity

        public DateTime ActivityDate { get; set; } // Date and time when the activity occurred

        [Required]
        public string ActivityType { get; set; } // Type of activity (e.g., "Exercise", "Meeting", "Purchase")

        [Required]
        public string Status { get; set; } // Status of the activity (e.g., "Completed", "Pending", "Cancelled")

        public int UserId { get; set; } // Foreign key for the user performing the activity

        public DateTime CreatedDate { get; set; } = DateTime.Now; // Date when the activity was logged

        public DateTime? LastUpdatedDate { get; set; } // Nullable field to track the last updated date

        public bool IsArchived { get; set; } = false; // Flag indicating whether the activity is archived (default is false)
        public ICollection<Lead> Leads { get; set; }
    }
}