using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace zohocrm3._0.Models
{
    public class Account
    {
         [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string AccountName { get; set; }

        [Required]
        [StringLength(50)]
        public string AccountNumber { get; set; }

        [Required]
        [Precision(18, 4)] // Specify precision and scale
        public decimal? Balance { get; set; }

        [Required]
        [StringLength(50)]
        public string AccountType { get; set; }  // e.g., "Savings", "Checking", "Business"

        public bool IsActive { get; set; } = true; // Default to true, meaning active

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? LastUpdatedDate { get; set; }

        public string Currency { get; set; } = "USD"; // Default to USD
        public ICollection<Lead> Leads { get; set; }
    }
}