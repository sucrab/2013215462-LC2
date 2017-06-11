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
    public class ContratoController : Controller
    {
        private readonly IUnityOfWork db;

       
        public ContratoController()
        {

        }
        public ContratoController(IUnityOfWork _db)
        {
            db = _db;
        }


        // GET: /Contrato/
        public ActionResult Index()
        {
            //var contrato = db.Contrato.Include(c => c.Venta);
            return View(db.Contrato.GetAll());
        }

        // GET: /Contrato/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = db.Contrato.Get(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            return View(contrato);
        }

        // GET: /Contrato/Create
        public ActionResult Create()
        {
            //ViewBag.ContratoID = new SelectList(db.Venta, "VentaID", "VentaID");
            return View();
        }

        // POST: /Contrato/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ContratoID,VentaID")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                db.Contrato.add(contrato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContratoID = new SelectList(db.Venta.GetAll(), "VentaID", "VentaID", contrato.ContratoID);
            return View(contrato);
        }

        // GET: /Contrato/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = db.Contrato.Get(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContratoID = new SelectList(db.Venta.GetAll(), "VentaID", "VentaID", contrato.ContratoID);
            return View(contrato);
        }

        // POST: /Contrato/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ContratoID,VentaID")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                db.StateModified(contrato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContratoID = new SelectList(db.Venta.GetAll(), "VentaID", "VentaID", contrato.ContratoID);
            return View(contrato);
        }

        // GET: /Contrato/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = db.Contrato.Get(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            return View(contrato);
        }

        // POST: /Contrato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contrato contrato = db.Contrato.Get(id);
            db.Contrato.Delete(contrato);
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
