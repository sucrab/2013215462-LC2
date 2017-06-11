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
    public class TipoPagoController : Controller
    {
        private readonly IUnityOfWork db;

       

        public TipoPagoController()
        {

        }

        public TipoPagoController(IUnityOfWork _db)
        {
            db = _db;
        }

        // GET: /TipoPago/
        public ActionResult Index()
        {
            return View(db.TipoPago.GetAll());
        }

        // GET: /TipoPago/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPago tipopago = db.TipoPago.Get(id);
            if (tipopago == null)
            {
                return HttpNotFound();
            }
            return View(tipopago);
        }

        // GET: /TipoPago/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TipoPago/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="TipoPagoID,VentaID")] TipoPago tipopago)
        {
            if (ModelState.IsValid)
            {
                db.TipoPago.add(tipopago);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipopago);
        }

        // GET: /TipoPago/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPago tipopago = db.TipoPago.Get(id);
            if (tipopago == null)
            {
                return HttpNotFound();
            }
            return View(tipopago);
        }

        // POST: /TipoPago/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="TipoPagoID,VentaID")] TipoPago tipopago)
        {
            if (ModelState.IsValid)
            {
                db.StateModified(tipopago);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipopago);
        }

        // GET: /TipoPago/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPago tipopago = db.TipoPago.Get(id);
            if (tipopago == null)
            {
                return HttpNotFound();
            }
            return View(tipopago);
        }

        // POST: /TipoPago/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoPago tipopago = db.TipoPago.Get(id);
            db.TipoPago.Delete(tipopago);
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
