using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace zohocrm3._0.Models
{
    public class Campaign
    {
        [Key]
        public int Id { get; set; } // Unique identifier for the campaign

        [Required]
        [StringLength(200)]
        public string CampaignName { get; set; } // Name or title of the campaign

        [StringLength(500)]
        public string Description { get; set; } // Description or details about the campaign

        public DateTime StartDate { get; set; } // The start date of the campaign

        public DateTime EndDate { get; set; } // The end date of the campaign

        [Required]
        public string Status { get; set; } // Status of the campaign (e.g., "Active", "Completed", "Pending")
        [Precision(18, 4)] // Specify precision and scale
        public decimal? Budget { get; set; } // Budget allocated for the campaign
        [Precision(18, 4)] // Specify precision and scale
        public decimal? AmountSpent { get; set; } // Amount spent so far on the campaign

        public int TargetAudienceId { get; set; } // Foreign key for the target audience (could link to another model, e.g., Audience)

        public DateTime CreatedDate { get; set; } = DateTime.Now; // The date when the campaign was created

        public DateTime? LastUpdatedDate { get; set; } // Nullable field to track the last updated date

        public bool IsArchived { get; set; } = false; // Flag indicating whether the campaign is archived
        public ICollection<Lead> Leads { get; set; }
    }
}