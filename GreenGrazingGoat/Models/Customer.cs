using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenGrazingGoat.Models
{
  public class Customer
  {
    public int CustomerID { get; set; }
    [Required]
    [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
    [Column("CustomerFirst")]
    [Display(Name = "First Name")]
    public string CustomerFirst { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
    [Column("CustomerLast")]
    [Display(Name = "Last Name")]
    public string CustomerLast { get; set; }

    [Column("CustomerAddress")]
    [Display(Name = "Address")]
    public string CustomerAddress { get; set; }

    [Column("CustomerEmail")]
    [Display(Name = "Email")]
    public string CustomerEmail { get; set; }

    public virtual Goat Goat { get; set; }
    public virtual Lot Lot { get; set; }

    // public virtual ICollection<Lot> Lots { get; set; }
  }
}
