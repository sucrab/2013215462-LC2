using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _2013215462_ENT;
using _2013215462_PER;
using _2013215462_ENT.lRepositories;

namespace _2013215462_MVC.Controllers
{
    public class ProvinciaController : Controller
    {
        private readonly IUnityOfWork db;

        
        public ProvinciaController()
        {

        }
        public ProvinciaController(IUnityOfWork _db)
        {
            db = _db;
        }


        // GET: /Provincia/
        public ActionResult Index()
        {
            //var provincia = db.Provincia.Include(p => p.Departamento);
            return View(db.Provincia.GetAll());
        }

        // GET: /Provincia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provincia provincia = db.Provincia.Get(id);
            if (provincia == null)
            {
                return HttpNotFound();
            }
            return View(provincia);
        }

        // GET: /Provincia/Create
        public ActionResult Create()
        {
            ViewBag.DepartamentoID = new SelectList(db.Departamento.GetAll(), "DepartamentoID", "DepartamentoID");
            return View();
        }

        // POST: /Provincia/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ProvinciaID,CadenaUbigeo,DepartamentoID")] Provincia provincia)
        {
            if (ModelState.IsValid)
            {
                db.Provincia.add(provincia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartamentoID = new SelectList(db.Departamento.GetAll(), "DepartamentoID", "DepartamentoID", provincia.DepartamentoID);
            return View(provincia);
        }

        // GET: /Provincia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provincia provincia = db.Provincia.Get(id);
            if (provincia == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartamentoID = new SelectList(db.Departamento.GetAll(), "DepartamentoID", "DepartamentoID", provincia.DepartamentoID);
            return View(provincia);
        }

        // POST: /Provincia/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ProvinciaID,CadenaUbigeo,DepartamentoID")] Provincia provincia)
        {
            if (ModelState.IsValid)
            {
                db.StateModified(provincia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartamentoID = new SelectList(db.Departamento.GetAll(), "DepartamentoID", "DepartamentoID", provincia.DepartamentoID);
            return View(provincia);
        }

        // GET: /Provincia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provincia provincia = db.Provincia.Get(id);
            if (provincia == null)
            {
                return HttpNotFound();
            }
            return View(provincia);
        }

        // POST: /Provincia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Provincia provincia = db.Provincia.Get(id);
            db.Provincia.Delete(provincia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
