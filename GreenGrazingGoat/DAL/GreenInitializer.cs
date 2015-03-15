using GreenGrazingGoat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreenGrazingGoat.DAL
{
  public class GreenInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<GreenContext>
  {
    protected override void Seed(GreenContext context)
    {
      var goats = new List<Goat>
            {
            new Goat{GoatID=1, GoatName="Carson",GoatColor="Black", GoatType="Alpine", GoatGender="Buck"},
            new Goat{GoatID=2, GoatName="Meredith",GoatColor="White",GoatType="Pygmy", GoatGender="Doe"},
            new Goat{GoatID=3, GoatName="Arturo",GoatColor="Red",GoatType="Cross", GoatGender="Doe"},
            new Goat{GoatID=4, GoatName="Gytis",GoatColor="Brown",GoatType="Boer", GoatGender="Buck"},
            };

      goats.ForEach(g => context.Goats.Add(g));
      context.SaveChanges();

      var pastures = new List<Pasture>
            {
              new Pasture{PastureID=1, GoatID=1, Field="A"},
              new Pasture{PastureID=2, GoatID=2, Field="B"},
              new Pasture{PastureID=3, GoatID=3, Field="C"},
              new Pasture{PastureID=4, GoatID=4, Field="D"},
            };
      pastures.ForEach(p => context.Pastures.Add(p));
      context.SaveChanges();

      var lots = new List<Lot>
            {
            new Lot{LotID= 1, GoatID=1, CustomerID=1, CustomerFirst="Ashley", CustomerLast="Smith", GoatName="Carson", LotAddress="123 West Ave", LotDescription= "Hill"},
            new Lot{LotID= 2, GoatID=2, CustomerID=2, CustomerFirst="Jerry", CustomerLast="Jones", GoatName="Meredith", LotAddress="456 East Ave", LotDescription= "Trees"},
            new Lot{LotID= 3, GoatID=3, CustomerID=3, CustomerFirst="Timmy", CustomerLast="Wilson",GoatName="Arturo", LotAddress="789 North Ave", LotDescription= "Level"},
            new Lot{LotID= 4, GoatID=4, CustomerID=4, CustomerFirst="Leo", CustomerLast="Lion",GoatName="Gytis", LotAddress="100 South Ave", LotDescription= "Forest"}
            };

      lots.ForEach(l => context.Lots.Add(l));
      context.SaveChanges();

      var customers = new List<Customer>
      {
        new Customer{CustomerID=1, CustomerFirst="Ashley", CustomerLast="Smith", CustomerEmail="ashley@email.com", CustomerAddress="123 West Ave",},
        new Customer{CustomerID=2, CustomerFirst="Jerry",CustomerLast="Jones", CustomerEmail="jerry@email.com", CustomerAddress="456 East Ave"},
        new Customer{CustomerID=3, CustomerFirst="Timmy",CustomerLast="Wilson", CustomerEmail="timmy@email.com", CustomerAddress="789 North Ave"},
        new Customer{CustomerID=4, CustomerFirst="Leo",CustomerLast="Lion", CustomerEmail="leo@email.com", CustomerAddress="100 South Ave"}
      };
      
     customers.ForEach(c => context.Customers.Add(c));
     context.SaveChanges();
    }
  }
}
  
