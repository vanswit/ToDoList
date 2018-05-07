using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.Models;
using ToDoList.Models.Repositories;

namespace ToDoList.Controllers
{
    public class ToDoController : Controller
    {
        // GET: ToDo
        public ActionResult Index()
        {
            //ViewModel model = new ViewModel();
            //List<ListItem> listItems = GetListItems("new", "in progress").ToList();
            //model.listItems = listItems;
            return View();
        }

        [HttpPost]
        public ActionResult Index(ViewModel model,string submitButton)
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
                    switch (submitButton)
                    {
                        case "Save":
                            SaveListItem(model,null);
                            break;
                        //case "Delete":
                        //    using (ToDoContext db = new ToDoContext())
                        //    {
                        //        db.ListItems.Attach(model.item);
                        //        db.ListItems.Remove(model.item);
                        //        db.SaveChanges();
                        //    }
                        //        break;
                        case "Start":
                            SaveListItem(model, "in progress");
                            break;
                        case "Complete":
                            SaveListItem(model, "complete");
                            break;

                    }
                }
            }
            List<ListItem> listItems = GetListItems("new","in progress").ToList();
            model.listItems = listItems;
            return View(model);
        }

        private IEnumerable<ListItem> GetListItems(params string[] states)
        {
            List<ListItem> listItems = new List<ListItem>();
            foreach (var state in states)
            {
                using (ToDoContext db = new ToDoContext())
                {
                    var q = from l in db.ListItems
                            where l.State == state
                            select l;

                    foreach (var item in q)
                    {
                        listItems.Add(item);
                    }
                }
            }
            return listItems;
        }

        private void SaveListItem(ViewModel model, string state)
        {
            using (ToDoContext db = new ToDoContext())
            {
                    var item = db.ListItems.Find(model.item.Id);
                    item.Id = model.item.Id;
                    if (state == null)
                    {
                        item.State = model.item.State;
                    }
                    else item.State = state;
                    item.Deadline = model.item.Deadline;
                    db.SaveChanges();
            }
        }

        public JsonResult Delete(int id)
        {
            return Json(ListItemRepo.Delete(id),JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListAll()
        {
            return Json(ListItemRepo.GetAllItems(), JsonRequestBehavior.AllowGet);
        }
    }
}