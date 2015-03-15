using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenGrazingGoat.Controllers
{
  public class SaleController : Controller
  {

    // GET: Sale
    public ActionResult Index()
    {
      ViewBag.MyMessageToUsers = "Goat Babies";
      return View();
    }
  }
}
