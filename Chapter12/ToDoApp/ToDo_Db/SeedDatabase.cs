using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Shared;

namespace ToDo_Db
{
    public class SeedDatabase
    {
        public static void Seed()
        {
            using (TodoContext db = new TodoContext())
            {
                db.Database.EnsureCreated();

                db.Shoppings.Add(new Shopping
                {
                    ShoppingItemId = new Guid(),
                    ShoppingItem = "Test",
                    Done = false,
                    Deleted = false,
                    Quantity = 11
                });
                
            }
        }
    }
}
