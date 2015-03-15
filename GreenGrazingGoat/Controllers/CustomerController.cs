using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GreenGrazingGoat.DAL;
using GreenGrazingGoat.Models;

namespace GreenGrazingGoat.Controllers
{
  public class CustomerController : Controller
  {
    private GreenContext db = new GreenContext();

    // GET: Customer
    public ActionResult Index(string sortOrder, string searchString)
    {

      var customers = from c in db.Customers
                      select c;

      if (!String.IsNullOrEmpty(searchString))
      {
        customers = customers.Where(c => c.CustomerLast.Contains(searchString));
      }

      return View(customers.ToList());

    }

    // GET: Customer/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Customer customer = db.Customers.Find(id);
      if (customer == null)
      {
        return HttpNotFound();
      }
      return View(customer);
    }

    // GET: Customer/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: Customer/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "CustomerID,CustomerFirst,Customer_Last,CustomerAddress,CustomerEmail")] Customer customer)
    {
      try
      {
        if (ModelState.IsValid)
        {
          db.Customers.Add(customer);
          db.SaveChanges();
          return RedirectToAction("Index");
        }
      }
      catch (DataException /* dex */)
      {
        //Log the error (uncomment dex variable name and add a line here to write a log.
        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
      }
      return View(customer);
    }
    // GET: Customer/Edit/5
    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Customer customer = db.Customers.Find(id);
      if (customer == null)
      {
        return HttpNotFound();
      }
      return View(customer);
    }

    // POST: Customer/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

    [HttpPost, ActionName("Edit")]
    [ValidateAntiForgeryToken]
    public ActionResult EditPost(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      var customerToUpdate = db.Customers.Find(id);
      if (TryUpdateModel(customerToUpdate, "",
         new string[] { "CustomerID", "CustomerFirst", "CustomerLast", "CustomerAddress", "CustomerEmail" }))
      {
        try
        {
          db.Entry(customerToUpdate).State = EntityState.Modified;
          db.SaveChanges();

          return RedirectToAction("Index");
        }
        catch (DataException /* dex */)
        {
          //Log the error (uncomment dex variable name and add a line here to write a log.
          ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
        }
      }
      return View(customerToUpdate);
    }

    // GET: Customer/Delete/5

    public ActionResult Delete(int? id, bool? saveChangesError = false)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      if (saveChangesError.GetValueOrDefault())
      {
        ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
      }
      Customer customer = db.Customers.Find(id);
      if (customer == null)
      {
        return HttpNotFound();
      }
      return View(customer);
    }

    // POST: Customer/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id)
    {
      try
      {
        Customer customer = db.Customers.Find(id);
        db.Customers.Remove(customer);
        db.SaveChanges();
      }
      catch (DataException/* dex */)
      {
        //Log the error (uncomment dex variable name and add a line here to write a log.
        return RedirectToAction("Delete", new { id = id, saveChangesError = true });
      }
      return RedirectToAction("Index");
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        db.Dispose();
      }
      base.Dispose(disposing);
    }
  }
}