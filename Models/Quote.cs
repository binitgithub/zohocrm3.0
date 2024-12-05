using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace zohocrm3._0.Models
{
    public class Quote
    {
        [Key]
        public int Id { get; set; } // Unique identifier for the quote

        [Required]
        public int CustomerId { get; set; } // Foreign key for the customer to whom the quote is given

        [Required]
        [StringLength(255)]
        public string QuoteDescription { get; set; } // Description or details of the quote
        [Precision(18, 4)] // Specify precision and scale
        public decimal TotalAmount { get; set; } // The total amount of the quote

        [Required]
        public DateTime IssueDate { get; set; } // The date when the quote was issued

        [Required]
        public DateTime ExpiryDate { get; set; } // The expiration date of the quote

        public string Status { get; set; } // Status of the quote, e.g., "Pending", "Approved", "Expired"

        public int SalesRepId { get; set; } // Foreign key for the sales representative handling the quote

        [StringLength(500)]
        public string TermsAndConditions { get; set; } // Optional field for the terms and conditions of the quote

        public bool IsConvertedToOrder { get; set; } = false; // Flag indicating if the quote has been converted to an order

        public DateTime CreatedDate { get; set; } = DateTime.Now; // The date when the quote was created

        public DateTime? LastUpdatedDate { get; set; } // Nullable field to track the last updated date
        public ICollection<Lead> Leads { get; set; }
        
    }
}