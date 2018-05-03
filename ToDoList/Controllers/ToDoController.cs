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

        public ActionResult Create()
        {
            return View();
        }
    }
}