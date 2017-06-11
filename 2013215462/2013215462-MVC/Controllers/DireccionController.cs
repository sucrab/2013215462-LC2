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
    public class DireccionController : Controller
    {
        private readonly IUnityOfWork db;

       

        public DireccionController()
        {

        }

        public DireccionController(IUnityOfWork _db)
        {
            db = _db;
        }

        // GET: /Direccion/
        public ActionResult Index()
        {
            //var direccion = db.Direccion.Include(d => d.CentroAtencion).Include(d => d.Distrito);
            return View(db.Direccion.GetAll());
        }

        // GET: /Direccion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = db.Direccion.Get(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // GET: /Direccion/Create
        public ActionResult Create()
        {
            ViewBag.DireccionID = new SelectList(db.CentroAtencion.GetAll(), "CentroAtencionID", "CentroAtencionID");
            ViewBag.DistritoID = new SelectList(db.Distrito.GetAll(), "DistritoID", "CadenaUbigeo");
            return View();
        }

        // POST: /Direccion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="DireccionID,CadenaUbigeo,CentroAtencionID,DistritoID")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                db.Direccion.add(direccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DireccionID = new SelectList(db.CentroAtencion.GetAll(), "CentroAtencionID", "CentroAtencionID", direccion.DireccionID);
            ViewBag.DistritoID = new SelectList(db.Distrito.GetAll(), "DistritoID", "CadenaUbigeo", direccion.DistritoID);
            return View(direccion);
        }

        // GET: /Direccion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = db.Direccion.Get(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.DireccionID = new SelectList(db.CentroAtencion.GetAll(), "CentroAtencionID", "CentroAtencionID", direccion.DireccionID);
            ViewBag.DistritoID = new SelectList(db.Distrito.GetAll(), "DistritoID", "CadenaUbigeo", direccion.DistritoID);
            return View(direccion);
        }

        // POST: /Direccion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="DireccionID,CadenaUbigeo,CentroAtencionID,DistritoID")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                db.StateModified(direccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DireccionID = new SelectList(db.CentroAtencion.GetAll(), "CentroAtencionID", "CentroAtencionID", direccion.DireccionID);
            ViewBag.DistritoID = new SelectList(db.Distrito.GetAll(), "DistritoID", "CadenaUbigeo", direccion.DistritoID);
            return View(direccion);
        }

        // GET: /Direccion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = db.Direccion.Get(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // POST: /Direccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Direccion direccion = db.Direccion.Get(id);
            db.Direccion.Delete(direccion);
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
