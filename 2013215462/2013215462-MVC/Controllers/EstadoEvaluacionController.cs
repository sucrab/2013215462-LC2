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
    public class EstadoEvaluacionController : Controller
    {
        private readonly IUnityOfWork db;

       
        public EstadoEvaluacionController()
        {

        }
        public EstadoEvaluacionController(IUnityOfWork _db)
        {
            db = _db;
        }
        // GET: /EstadoEvaluacion/
        public ActionResult Index()
        {
            return View(db.EstadoEvaluacion.GetAll());
        }

        // GET: /EstadoEvaluacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoEvaluacion estadoevaluacion = db.EstadoEvaluacion.Get(id);
            if (estadoevaluacion == null)
            {
                return HttpNotFound();
            }
            return View(estadoevaluacion);
        }

        // GET: /EstadoEvaluacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /EstadoEvaluacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="EstadoEvaluacionID,EvaluacionID")] EstadoEvaluacion estadoevaluacion)
        {
            if (ModelState.IsValid)
            {
                db.EstadoEvaluacion.add(estadoevaluacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estadoevaluacion);
        }

        // GET: /EstadoEvaluacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoEvaluacion estadoevaluacion = db.EstadoEvaluacion.Get(id);
            if (estadoevaluacion == null)
            {
                return HttpNotFound();
            }
            return View(estadoevaluacion);
        }

        // POST: /EstadoEvaluacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="EstadoEvaluacionID,EvaluacionID")] EstadoEvaluacion estadoevaluacion)
        {
            if (ModelState.IsValid)
            {
                db.StateModified(estadoevaluacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estadoevaluacion);
        }

        // GET: /EstadoEvaluacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoEvaluacion estadoevaluacion = db.EstadoEvaluacion.Get(id);
            if (estadoevaluacion == null)
            {
                return HttpNotFound();
            }
            return View(estadoevaluacion);
        }

        // POST: /EstadoEvaluacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EstadoEvaluacion estadoevaluacion = db.EstadoEvaluacion.Get(id);
            db.EstadoEvaluacion.Delete(estadoevaluacion);
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
