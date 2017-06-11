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
    public class DistritoController : Controller
    {
        private readonly IUnityOfWork db;

        
        public DistritoController()
        {

        }

        public DistritoController(IUnityOfWork _db)
        {
            db = _db;
        }


        // GET: /Distrito/
        public ActionResult Index()
        {
            //var distrito = db.Distrito.Include(d => d.Provincia);
            return View(db.Distrito.GetAll());
        }

        // GET: /Distrito/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distrito distrito = db.Distrito.Get(id);
            if (distrito == null)
            {
                return HttpNotFound();
            }
            return View(distrito);
        }

        // GET: /Distrito/Create
        public ActionResult Create()
        {
            ViewBag.ProvinciaID = new SelectList(db.Provincia.GetAll(), "ProvinciaID", "CadenaUbigeo");
            return View();
        }

        // POST: /Distrito/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="DistritoID,ProvinciaID,CadenaUbigeo")] Distrito distrito)
        {
            if (ModelState.IsValid)
            {
                db.Distrito.add(distrito);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProvinciaID = new SelectList(db.Provincia.GetAll(), "ProvinciaID", "CadenaUbigeo", distrito.ProvinciaID);
            return View(distrito);
        }

        // GET: /Distrito/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distrito distrito = db.Distrito.Get(id);
            if (distrito == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProvinciaID = new SelectList(db.Provincia.GetAll(), "ProvinciaID", "CadenaUbigeo", distrito.ProvinciaID);
            return View(distrito);
        }

        // POST: /Distrito/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="DistritoID,ProvinciaID,CadenaUbigeo")] Distrito distrito)
        {
            if (ModelState.IsValid)
            {
                db.StateModified(distrito);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProvinciaID = new SelectList(db.Provincia.GetAll(), "ProvinciaID", "CadenaUbigeo", distrito.ProvinciaID);
            return View(distrito);
        }

        // GET: /Distrito/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distrito distrito = db.Distrito.Get(id);
            if (distrito == null)
            {
                return HttpNotFound();
            }
            return View(distrito);
        }

        // POST: /Distrito/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Distrito distrito = db.Distrito.Get(id);
            db.Distrito.Delete(distrito);
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
