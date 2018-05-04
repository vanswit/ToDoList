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
            ViewModel model = new ViewModel();
            List<ListItem> listItems = GetListItems().ToList();
            model.listItems = listItems;
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.item.Id == null)
                {
                    using(ToDoContext db = new ToDoContext())
                    {
                        model.item.State = "new";
                        db.ListItems.Add(model.item);
                        db.SaveChanges();
                    }
                }
                else
                {
                    using (ToDoContext db = new ToDoContext())
                    {
                        var item = db.ListItems.Find(model.item.Id);
                        item.Id = model.item.Id;
                        item.State = model.item.State;
                        item.Deadline = model.item.Deadline;
                        item.State = model.item.State;
                        db.SaveChanges();
                    }
                }
            }
            List<ListItem> listItems = GetListItems().ToList();
            model.listItems = listItems;
            return View(model);
        }

        private IEnumerable<ListItem> GetListItems()
        {
            List<ListItem> listItems = new List<ListItem>();
            using (ToDoContext db = new ToDoContext())
            {
                listItems = db.ListItems.ToList();
            }
            return listItems;
        }
    }
}