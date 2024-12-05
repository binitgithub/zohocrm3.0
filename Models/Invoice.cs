using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace zohocrm3._0.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; } // Unique identifier for the invoice

        [Required]
        public int CustomerId { get; set; } // Foreign key for the customer to whom the invoice is billed

        [Required]
        public DateTime IssueDate { get; set; } // The date when the invoice is generated

        [Required]
        public DateTime DueDate { get; set; } // The due date for payment

        [Required]
        [Precision(18, 4)] // Specify precision and scale
        public decimal TotalAmount { get; set; } // Total amount of the invoice (after applying discounts, taxes, etc.)

        [Required]
        [Precision(18, 4)] // Specify precision and scale
        public decimal AmountPaid { get; set; } // Amount that has been paid (can be 0 initially)
        
        [Precision(18, 4)] // Specify precision and scale
        public decimal AmountDue { get; set; } // Amount that is still due (calculated as TotalAmount - AmountPaid)

        [StringLength(500)]
        public string Description { get; set; } // Optional description of the invoice (e.g., details of services/products billed)

        public string Status { get; set; } // Status of the invoice, e.g., "Paid", "Unpaid", "Partially Paid", "Overdue"

        public int SalesRepId { get; set; } // Foreign key for the sales representative who generated the invoice

        public string TermsAndConditions { get; set; } // Optional field for the terms and conditions of the invoice

        public DateTime CreatedDate { get; set; } = DateTime.Now; // The date when the invoice record was created

        public DateTime? LastUpdatedDate { get; set; } // Nullable field to track the last updated date

        public bool IsArchived { get; set; } = false; // Boolean flag indicating whether the invoice is archived (default is false)
        public ICollection<Lead> Leads { get; set; }
    }
}