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
    public class EvaluacionController : Controller
    {
        private readonly IUnityOfWork db;
        
        
        public EvaluacionController()
        {

        }

        public EvaluacionController(IUnityOfWork _db)
        {
            db = _db;
        }
        // GET: /Evaluacion/
        public ActionResult Index()
        {
            //var evaluacion = db.Evaluacion.Include(e => e.CentroAtencion).Include(e => e.Trabajador).Include(e => e.Venta);
            return View(db.Evaluacion.GetAll());
        }

        // GET: /Evaluacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluacion evaluacion = db.Evaluacion.Get(id);
            if (evaluacion == null)
            {
                return HttpNotFound();
            }
            return View(evaluacion);
        }

        // GET: /Evaluacion/Create
        public ActionResult Create()
        {
            ViewBag.CentroAtencionID = new SelectList(db.CentroAtencion.GetAll(), "CentroAtencionID", "CentroAtencionID");
            ViewBag.TrabajadorID = new SelectList(db.Trabajador.GetAll(), "TrabajadorID", "TrabajadorID");
            ViewBag.EvaluacionID = new SelectList(db.Venta.GetAll(), "VentaID", "VentaID");
            return View();
        }

        // POST: /Evaluacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="EvaluacionID,VentaID,TrabajadorID,CentroAtencionID")] Evaluacion evaluacion)
        {
            if (ModelState.IsValid)
            {
                db.Evaluacion.add(evaluacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CentroAtencionID = new SelectList(db.CentroAtencion.GetAll(), "CentroAtencionID", "CentroAtencionID", evaluacion.CentroAtencionID);
            ViewBag.TrabajadorID = new SelectList(db.Trabajador.GetAll(), "TrabajadorID", "TrabajadorID", evaluacion.TrabajadorID);
            ViewBag.EvaluacionID = new SelectList(db.Venta.GetAll(), "VentaID", "VentaID", evaluacion.EvaluacionID);
            return View(evaluacion);
        }

        // GET: /Evaluacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluacion evaluacion = db.Evaluacion.Get(id);
            if (evaluacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.CentroAtencionID = new SelectList(db.CentroAtencion.GetAll(), "CentroAtencionID", "CentroAtencionID", evaluacion.CentroAtencionID);
            ViewBag.TrabajadorID = new SelectList(db.Trabajador.GetAll(), "TrabajadorID", "TrabajadorID", evaluacion.TrabajadorID);
            ViewBag.EvaluacionID = new SelectList(db.Venta.GetAll(), "VentaID", "VentaID", evaluacion.EvaluacionID);
            return View(evaluacion);
        }

        // POST: /Evaluacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="EvaluacionID,VentaID,TrabajadorID,CentroAtencionID")] Evaluacion evaluacion)
        {
            if (ModelState.IsValid)
            {
                db.StateModified(evaluacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CentroAtencionID = new SelectList(db.CentroAtencion.GetAll(), "CentroAtencionID", "CentroAtencionID", evaluacion.CentroAtencionID);
            ViewBag.TrabajadorID = new SelectList(db.Trabajador.GetAll(), "TrabajadorID", "TrabajadorID", evaluacion.TrabajadorID);
            ViewBag.EvaluacionID = new SelectList(db.Venta.GetAll(), "VentaID", "VentaID", evaluacion.EvaluacionID);
            return View(evaluacion);
        }

        // GET: /Evaluacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluacion evaluacion = db.Evaluacion.Get(id);
            if (evaluacion == null)
            {
                return HttpNotFound();
            }
            return View(evaluacion);
        }

        // POST: /Evaluacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Evaluacion evaluacion = db.Evaluacion.Get(id);
            db.Evaluacion.Delete(evaluacion);
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
