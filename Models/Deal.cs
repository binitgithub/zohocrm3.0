using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace zohocrm3._0.Models
{
    public class Deal
    {
    [Key]
    public int Id { get; set; }

    [Required, StringLength(200)]
    public string DealName { get; set; }

    [Required]
    [Precision(18, 4)] // Specify precision and scale
    public decimal DealAmount { get; set; }

    public DateTime DealStartDate { get; set; } = DateTime.Now;

    public DateTime? DealEndDate { get; set; }

    [Required]
    public string Status { get; set; }

    public int AccountId { get; set; }
    public Account Account { get; set; }

    [StringLength(500)]
    public string Description { get; set; }

    [Required]
    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime? LastUpdatedDate { get; set; }
    public ICollection<Lead> Leads { get; set; }
    }
}