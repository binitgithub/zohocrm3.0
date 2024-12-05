using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace zohocrm3._0.Models
{
    public class Lead
    {
    [Key]
    public int Id { get; set; }

    [Required, StringLength(100)]
    public string FirstName { get; set; }

    [Required, StringLength(100)]
    public string LastName { get; set; }

    [Required, EmailAddress]
    public string Mail { get; set; }

    [Phone]
    public string PhoneNumber { get; set; }

    [StringLength(250)]
    public string Company { get; set; }

    [StringLength(500)]
    public string Notes { get; set; }

    [Required]
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime? LastContactDate { get; set; }

    public bool IsQualified { get; set; } = false;

     // Navigation properties and foreign key relationships
        public int AccountId { get; set; }
        public Account Account { get; set; }

        public int ActivityId { get; set; }
        public Activity Activity { get; set; }

        public int ApptaskId { get; set; }
        public Apptask Apptask { get; set; }

        public int CampaignId { get; set; }
        public Campaign Campaign { get; set; }

        public int ContactId { get; set; }
        public Contact Contact { get; set; }

        public int DealId { get; set; }
        public Deal Deal { get; set; }

        public int EmailId { get; set; }
        public Email Email { get; set; }

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        public int QuoteId { get; set; }
        public Quote Quote { get; set; }
    }
}