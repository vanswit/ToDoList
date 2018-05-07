using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoList.Models.Repositories
{
    public static class ListItemRepo
    {
        public static int Delete(int id)
        {
            using (ToDoContext db = new ToDoContext())
            {
                ListItem item = new ListItem() { Id = id };
                db.ListItems.Attach(item);
                db.ListItems.Remove(item);
                return db.SaveChanges();
            }
        }

        public static List<ListItem> GetAllItems()
        {
            using (ToDoContext db = new ToDoContext())
            {
                return db.ListItems.ToList();
            }
        }
    }
}