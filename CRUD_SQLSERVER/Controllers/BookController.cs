using CRUD_SQLSERVER.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_SQLSERVER.Controllers
{
    public class BookController : Controller
    {
        // GET: Bookt
        public ActionResult Index()
        {
            using(DbModels context= new DbModels() )
            {
                return View(context.Books.ToList());
            }
           
        }

        // GET: Bookt/Details/5
        public ActionResult Details(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.Books.Where(x => x.ID==id));
            }
        }

        // GET: Bookt/Create
        public ActionResult Create()
        {
            return View();
            
        }

        // POST: Bookt/Create
        [HttpPost]
        public ActionResult Create(Books books )
        {
            try
            {
                using(DbModels context = new DbModels())
                {
                   context.Books.Add(books);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bookt/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.Books.Where(x => x.ID == id).FirstOrDefault());
            }
        }

        // POST: Bookt/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Books books)
        {
            try
            {
                using(DbModels context=new DbModels())
                {
                    context.Entry(books).State = EntityState.Modified;
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bookt/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.Books.Where(x => x.ID == id).FirstOrDefault());
            }
        }

        // POST: Bookt/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using(DbModels context=new DbModels())
                {
                    Books book = context.Books.Where(x=>x.ID==id).FirstOrDefault();
                    context.Books.Remove(book);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
