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
    public class TipoEvaluacionController : Controller
    {
        private readonly IUnityOfWork db;

        public TipoEvaluacionController()
        {

        }


        public TipoEvaluacionController(IUnityOfWork _db)
        {
            db = _db;
        }

        // GET: /TipoEvaluacion/
        public ActionResult Index()
        {
            return View(db.TipoEvaluacion.GetAll());
        }

        // GET: /TipoEvaluacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEvaluacion tipoevaluacion = db.TipoEvaluacion.Get(id);
            if (tipoevaluacion == null)
            {
                return HttpNotFound();
            }
            return View(tipoevaluacion);
        }

        // GET: /TipoEvaluacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TipoEvaluacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="TipoEvaluacionID,EvaluacionID")] TipoEvaluacion tipoevaluacion)
        {
            if (ModelState.IsValid)
            {
                db.TipoEvaluacion.add(tipoevaluacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoevaluacion);
        }

        // GET: /TipoEvaluacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEvaluacion tipoevaluacion = db.TipoEvaluacion.Get(id);
            if (tipoevaluacion == null)
            {
                return HttpNotFound();
            }
            return View(tipoevaluacion);
        }

        // POST: /TipoEvaluacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="TipoEvaluacionID,EvaluacionID")] TipoEvaluacion tipoevaluacion)
        {
            if (ModelState.IsValid)
            {
                db.StateModified(tipoevaluacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoevaluacion);
        }

        // GET: /TipoEvaluacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEvaluacion tipoevaluacion = db.TipoEvaluacion.Get(id);
            if (tipoevaluacion == null)
            {
                return HttpNotFound();
            }
            return View(tipoevaluacion);
        }

        // POST: /TipoEvaluacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoEvaluacion tipoevaluacion = db.TipoEvaluacion.Get(id);
            db.TipoEvaluacion.Delete(tipoevaluacion);
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
