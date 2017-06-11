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
    public class LineaTelefonicaController : Controller
    {
        private readonly IUnityOfWork db;

       
        public LineaTelefonicaController()
        {
                
        }

        public LineaTelefonicaController(IUnityOfWork _db)
        {
            db = _db;
        }


        // GET: /LineaTelefonica/
        public ActionResult Index()
        {
            //var lineatelefonica = db.LineaTelefonica.Include(l => l.AdministradorLinea).Include(l => l.Venta);
            return View(db.LineaTelefonica.GetAll());
        }

        // GET: /LineaTelefonica/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LineaTelefonica lineatelefonica = db.LineaTelefonica.Get(id);
            if (lineatelefonica == null)
            {
                return HttpNotFound();
            }
            return View(lineatelefonica);
        }

        // GET: /LineaTelefonica/Create
        public ActionResult Create()
        {
            ViewBag.AdministradorLineaID = new SelectList(db.AdministradorLinea.GetAll(), "AdministradorLineaID", "AdministradorLineaID");
            ViewBag.LineaTelefonicaID = new SelectList(db.Venta.GetAll(), "VentaID", "VentaID");
            return View();
        }

        // POST: /LineaTelefonica/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="LineaTelefonicaID,AdministradorLineaID,VentaID,EvaluacionID")] LineaTelefonica lineatelefonica)
        {
            if (ModelState.IsValid)
            {
                db.LineaTelefonica.add(lineatelefonica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AdministradorLineaID = new SelectList(db.AdministradorLinea.GetAll(), "AdministradorLineaID", "AdministradorLineaID", lineatelefonica.AdministradorLineaID);
            ViewBag.LineaTelefonicaID = new SelectList(db.Venta.GetAll(), "VentaID", "VentaID", lineatelefonica.LineaTelefonicaID);
            return View(lineatelefonica);
        }

        // GET: /LineaTelefonica/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LineaTelefonica lineatelefonica = db.LineaTelefonica.Get(id);
            if (lineatelefonica == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdministradorLineaID = new SelectList(db.AdministradorLinea.GetAll(), "AdministradorLineaID", "AdministradorLineaID", lineatelefonica.AdministradorLineaID);
            ViewBag.LineaTelefonicaID = new SelectList(db.Venta.GetAll(), "VentaID", "VentaID", lineatelefonica.LineaTelefonicaID);
            return View(lineatelefonica);
        }

        // POST: /LineaTelefonica/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="LineaTelefonicaID,AdministradorLineaID,VentaID,EvaluacionID")] LineaTelefonica lineatelefonica)
        {
            if (ModelState.IsValid)
            {
                db.StateModified(lineatelefonica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdministradorLineaID = new SelectList(db.AdministradorLinea.GetAll(), "AdministradorLineaID", "AdministradorLineaID", lineatelefonica.AdministradorLineaID);
            ViewBag.LineaTelefonicaID = new SelectList(db.Venta.GetAll(), "VentaID", "VentaID", lineatelefonica.LineaTelefonicaID);
            return View(lineatelefonica);
        }

        // GET: /LineaTelefonica/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LineaTelefonica lineatelefonica = db.LineaTelefonica.Get(id);
            if (lineatelefonica == null)
            {
                return HttpNotFound();
            }
            return View(lineatelefonica);
        }

        // POST: /LineaTelefonica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LineaTelefonica lineatelefonica = db.LineaTelefonica.Get(id);
            db.LineaTelefonica.Delete(lineatelefonica);
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
