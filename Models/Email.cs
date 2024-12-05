using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace zohocrm3._0.Models
{
    public class Email
    {
        [Key]
        public int Id { get; set; } // Unique identifier for the email record

        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string From { get; set; } // Sender email address

        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string To { get; set; } // Recipient email address

        [StringLength(255)]
        public string Cc { get; set; } // Carbon Copy (Optional)

        [StringLength(255)]
        public string Bcc { get; set; } // Blind Carbon Copy (Optional)

        [Required]
        [StringLength(500)]
        public string Subject { get; set; } // Subject of the email

        [Required]
        public string Body { get; set; } // Body content of the email

        public DateTime SentDate { get; set; } // Date and time when the email was sent

        public bool IsRead { get; set; } = false; // Boolean indicating whether the email has been read

        public bool IsArchived { get; set; } = false; // Boolean indicating whether the email is archived

        public string AttachmentUrls { get; set; } // A comma-separated string or JSON to store URLs of attachments (optional)

        public DateTime CreatedDate { get; set; } = DateTime.Now; // Date when the email record was created

        public DateTime? LastUpdatedDate { get; set; } // Nullable field to track the last updated date
        public ICollection<Lead> Leads { get; set; }
    }
}