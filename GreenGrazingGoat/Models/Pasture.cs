using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreenGrazingGoat.Models
{
  public class Pasture
  {
    public int PastureID { get; set; }
    public int GoatID { get; set; }
    public string Field { get; set; }
    public virtual Goat Goat { get; set; }

  }
}