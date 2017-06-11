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
    public class VentaController : Controller
    {
        private readonly IUnityOfWork db;
       

        public VentaController()
        {

        }
        public VentaController(IUnityOfWork _db)
        {
            db = _db;
        }

        // GET: /Venta/
        public ActionResult Index()
        {
            //var venta = db.Venta.Include(v => v.CentroAtencion);
            return View(db.Venta.GetAll());
        }

        // GET: /Venta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Venta.Get(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // GET: /Venta/Create
        public ActionResult Create()
        {
            ViewBag.CentroAtencionID = new SelectList(db.CentroAtencion.GetAll(), "CentroAtencionID", "CentroAtencionID");
            return View();
        }

        // POST: /Venta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="VentaID,CentroAtencionID")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                db.Venta.add(venta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CentroAtencionID = new SelectList(db.CentroAtencion.GetAll(), "CentroAtencionID", "CentroAtencionID", venta.CentroAtencionID);
            return View(venta);
        }

        // GET: /Venta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Venta.Get(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            ViewBag.CentroAtencionID = new SelectList(db.CentroAtencion.GetAll(), "CentroAtencionID", "CentroAtencionID", venta.CentroAtencionID);
            return View(venta);
        }

        // POST: /Venta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="VentaID,CentroAtencionID")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                db.StateModified(venta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CentroAtencionID = new SelectList(db.CentroAtencion.GetAll(), "CentroAtencionID", "CentroAtencionID", venta.CentroAtencionID);
            return View(venta);
        }

        // GET: /Venta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Venta.Get(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // POST: /Venta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Venta venta = db.Venta.Get(id);
            db.Venta.Delete(venta);
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
