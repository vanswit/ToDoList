using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ToDoList.Models
{
    public class ToDoContext : DbContext
    {
        public DbSet<ListItem> ListItems { get; set; }
    }
}