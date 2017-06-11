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
    public class TrabajadorController : Controller
    {
        private readonly IUnityOfWork db;

       

        public TrabajadorController()
        {

        }

        public TrabajadorController(IUnityOfWork _db)
        {
            db = _db;
        }
        // GET: /Trabajador/
        public ActionResult Index()
        {
            return View(db.Trabajador.GetAll());
        }

        // GET: /Trabajador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajador trabajador = db.Trabajador.Get(id);
            if (trabajador == null)
            {
                return HttpNotFound();
            }
            return View(trabajador);
        }

        // GET: /Trabajador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Trabajador/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="TrabajadorID,EvaluacionID")] Trabajador trabajador)
        {
            if (ModelState.IsValid)
            {
                db.Trabajador.add(trabajador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trabajador);
        }

        // GET: /Trabajador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajador trabajador = db.Trabajador.Get(id);
            if (trabajador == null)
            {
                return HttpNotFound();
            }
            return View(trabajador);
        }

        // POST: /Trabajador/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="TrabajadorID,EvaluacionID")] Trabajador trabajador)
        {
            if (ModelState.IsValid)
            {
                db.StateModified(trabajador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trabajador);
        }

        // GET: /Trabajador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajador trabajador = db.Trabajador.Get(id);
            if (trabajador == null)
            {
                return HttpNotFound();
            }
            return View(trabajador);
        }

        // POST: /Trabajador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trabajador trabajador = db.Trabajador.Get(id);
            db.Trabajador.Delete(trabajador);
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
