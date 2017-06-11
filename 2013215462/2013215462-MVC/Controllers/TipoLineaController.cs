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
    public class TipoLineaController : Controller
    {
        private readonly IUnityOfWork db;

      
        public TipoLineaController()
        {

        }

        public TipoLineaController(IUnityOfWork _db)
        {
            db = _db;
        }

        // GET: /TipoLinea/
        public ActionResult Index()
        {
            return View(db.TipoLinea.GetAll());
        }

        // GET: /TipoLinea/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoLinea tipolinea = db.TipoLinea.Get(id);
            if (tipolinea == null)
            {
                return HttpNotFound();
            }
            return View(tipolinea);
        }

        // GET: /TipoLinea/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TipoLinea/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="TipoLineaID,LineaTelefonicaID")] TipoLinea tipolinea)
        {
            if (ModelState.IsValid)
            {
                db.TipoLinea.add(tipolinea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipolinea);
        }

        // GET: /TipoLinea/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoLinea tipolinea = db.TipoLinea.Get(id);
            if (tipolinea == null)
            {
                return HttpNotFound();
            }
            return View(tipolinea);
        }

        // POST: /TipoLinea/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="TipoLineaID,LineaTelefonicaID")] TipoLinea tipolinea)
        {
            if (ModelState.IsValid)
            {
                db.StateModified(tipolinea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipolinea);
        }

        // GET: /TipoLinea/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoLinea tipolinea = db.TipoLinea.Get(id);
            if (tipolinea == null)
            {
                return HttpNotFound();
            }
            return View(tipolinea);
        }

        // POST: /TipoLinea/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoLinea tipolinea = db.TipoLinea.Get(id);
            db.TipoLinea.Delete(tipolinea);
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
