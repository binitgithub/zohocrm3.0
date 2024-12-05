using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace zohocrm3._0.Models
{
    public class Apptask
    {
        [Key]
        public int Id { get; set; } // Unique identifier for the task

        [Required]
        [StringLength(200)]
        public string TaskName { get; set; } // Name or title of the task

        [StringLength(500)]
        public string Description { get; set; } // Description or details of the task

        public DateTime DueDate { get; set; } // Task due date

        public DateTime? CompletedDate { get; set; } // Nullable, the date when the task was completed

        [Required]
        public string Priority { get; set; } // Priority of the task (e.g., "Low", "Medium", "High")

        [Required]
        public string Status { get; set; } // Status of the task (e.g., "Pending", "In Progress", "Completed")

        public int AssignedToUserId { get; set; } // Foreign key for the user assigned to the task

        public DateTime CreatedDate { get; set; } = DateTime.Now; // Task creation date

        public DateTime? LastUpdatedDate { get; set; } // Nullable field to track the last updated date

        public bool IsArchived { get; set; } = false; // Boolean flag to mark the task as archived (default is false)
        public ICollection<Lead> Leads { get; set; }
    }
}