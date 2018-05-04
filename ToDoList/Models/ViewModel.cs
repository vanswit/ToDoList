using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoList.Models
{
    public class ViewModel
    {
        public ListItem item { get; set; }
        public List<ListItem> listItems { get; set; }
    }
}