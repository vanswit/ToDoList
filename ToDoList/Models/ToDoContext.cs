using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ToDoList.Models
{
    public class ToDoContext : DbContext, IDisposable
    {
        public DbSet<ListItem> ListItems { get; set; }
    }
}