using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace zohocrm3._0.Models
{
    public class Contact
    {
    [Key]
    public int Id { get; set; }

    [Required, StringLength(100)]
    public string FirstName { get; set; }

    [Required, StringLength(100)]
    public string LastName { get; set; }

    [EmailAddress, StringLength(200)]
    public string Email { get; set; }

    [Phone, StringLength(15)]
    public string PhoneNumber { get; set; }

    [StringLength(250)]
    public string Address { get; set; }

    [StringLength(100)]
    public string City { get; set; }

    [StringLength(100)]
    public string State { get; set; }

    [StringLength(20)]
    public string ZipCode { get; set; }

    [StringLength(100)]
    public string Country { get; set; }

    [StringLength(500)]
    public string Notes { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime? LastUpdatedDate { get; set; }
    public ICollection<Lead> Leads { get; set; }
    }
}