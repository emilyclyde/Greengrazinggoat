using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenGrazingGoat.Models
{
  public class Lot
  {
    public int LotID { get; set; }

    [Column("GoatID")]
    [Display(Name = "Goat ID")]
    [Range(1, 4)]
    public int GoatID { get; set; }

    [Column("CustomerID")]
    [Display(Name = "Customer ID")]
    public int CustomerID { get; set; }

    [Required]
    [StringLength(50)]
    [Column("GoatName")]
    [Display(Name = "Goat Name")]
    public string GoatName { get; set; }

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

    [Required]
    [StringLength(50)]
    [Column("LotAddress")]
    [Display(Name = "Lot Address")]
    public string LotAddress { get; set; }

    [Column("LotDescription")]
    [Display(Name = "Lot Description")]
    public string LotDescription { get; set; }


  }
}