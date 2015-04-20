using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pruebas.Models;

namespace pruebas.Controllers
{ 
    public class ProveedorController : Controller
    {
        private pruebasEntities db = new pruebasEntities();

        //
        // GET: /Proveedor/

        public ViewResult Index()
        {
            return View(db.proveedor.ToList());
        }

        //
        // GET: /Proveedor/Details/5

        public ViewResult Details(int id)
        {
            proveedor proveedor = db.proveedor.Find(id);
            return View(proveedor);
        }

        //
        // GET: /Proveedor/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Proveedor/Create

        [HttpPost]
        public ActionResult Create(proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                db.proveedor.Add(proveedor);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(proveedor);
        }
        
        //
        // GET: /Proveedor/Edit/5
 
        public ActionResult Edit(int id)
        {
            proveedor proveedor = db.proveedor.Find(id);
            return View(proveedor);
        }

        //
        // POST: /Proveedor/Edit/5

        [HttpPost]
        public ActionResult Edit(proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proveedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proveedor);
        }

        //
        // GET: /Proveedor/Delete/5
 
        public ActionResult Delete(int id)
        {
            proveedor proveedor = db.proveedor.Find(id);
            return View(proveedor);
        }

        //
        // POST: /Proveedor/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            proveedor proveedor = db.proveedor.Find(id);
            db.proveedor.Remove(proveedor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}