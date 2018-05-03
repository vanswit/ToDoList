using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ToDoController : Controller
    {
        // GET: ToDo
        public ActionResult Index()
        {
            List<ListItem> listItems = new List<ListItem>();
            using (ToDoContext db = new ToDoContext())
            {
                listItems = db.ListItems.ToList();
            }
            return View(listItems);
        }

        [HttpPost]
        public ActionResult Index(ListItem listItem)
        {
            using (ToDoContext db = new ToDoContext())
            {
                var item = db.ListItems.Find(listItem.Id);
                item.State = listItem.State;
                item.Deadline = listItem.Deadline;
                item.State = listItem.State;
                db.SaveChanges();
            }

            return View("Index");
        }
    }
}