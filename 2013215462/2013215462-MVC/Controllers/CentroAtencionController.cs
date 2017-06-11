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
    public class CentroAtencionController : Controller
    {
        private readonly IUnityOfWork db;

        public CentroAtencionController()
        {

        }

        public CentroAtencionController( IUnityOfWork _db)
        {
            db = _db;

        }

        // GET: /CentroAtencion/
        public ActionResult Index()
        {
            return View(db.CentroAtencion.GetAll());
        }

        // GET: /CentroAtencion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CentroAtencion centroatencion = db.CentroAtencion.Get(id);
            if (centroatencion == null)
            {
                return HttpNotFound();
            }
            return View(centroatencion);
        }

        // GET: /CentroAtencion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /CentroAtencion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CentroAtencionID,DireccionID,EvaluacionID,VentaID")] CentroAtencion centroatencion)
        {
            if (ModelState.IsValid)
            {
                db.CentroAtencion.add(centroatencion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(centroatencion);
        }

        // GET: /CentroAtencion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CentroAtencion centroatencion = db.CentroAtencion.Get(id);
            if (centroatencion == null)
            {
                return HttpNotFound();
            }
            return View(centroatencion);
        }

        // POST: /CentroAtencion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CentroAtencionID,DireccionID,EvaluacionID,VentaID")] CentroAtencion centroatencion)
        {
            if (ModelState.IsValid)
            {
                db.StateModified(centroatencion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(centroatencion);
        }

        // GET: /CentroAtencion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CentroAtencion centroatencion = db.CentroAtencion.Get(id);
            if (centroatencion == null)
            {
                return HttpNotFound();
            }
            return View(centroatencion);
        }

        // POST: /CentroAtencion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CentroAtencion centroatencion = db.CentroAtencion.Get(id);
            db.CentroAtencion.Delete(centroatencion);
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
