using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoList.Models
{
    public class ListItem
    {
        public int Id { get; private set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public string State { get; set; }

        public ListItem()
        {

        }

        public ListItem(string description, DateTime deadline)
        {
            Description = description;
            Deadline = deadline;
        }
    }
}