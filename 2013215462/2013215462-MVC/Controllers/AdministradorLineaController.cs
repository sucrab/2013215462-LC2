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
    public class AdministradorLineaController : Controller
    {
        private readonly IUnityOfWork db;

        public AdministradorLineaController()
        {

        }

        public AdministradorLineaController(IUnityOfWork _db)
        {
            db = _db;
        }

        // GET: /AdministradorLinea/
        public ActionResult Index()
        {
            return View(db.AdministradorLinea.GetAll());
        }

        // GET: /AdministradorLinea/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AdministradorLinea administradorlinea = db.AdministradorLinea.Get(id);

            if (administradorlinea == null)
            {
                return HttpNotFound();
            }
            return View(administradorlinea);
        }

        // GET: /AdministradorLinea/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /AdministradorLinea/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="AdministradorLineaID")] AdministradorLinea administradorlinea)
        {
            if (ModelState.IsValid)
            {
                db.AdministradorLinea.add(administradorlinea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(administradorlinea);
        }

        // GET: /AdministradorLinea/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AdministradorLinea administradorlinea = db.AdministradorLinea.Get(id);

            if (administradorlinea == null)
            {
                return HttpNotFound();
            }
            return View(administradorlinea);
        }

        // POST: /AdministradorLinea/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="AdministradorLineaID")] AdministradorLinea administradorlinea)
        {
            if (ModelState.IsValid)
            {
                db.StateModified(administradorlinea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(administradorlinea);
        }

        // GET: /AdministradorLinea/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdministradorLinea administradorlinea = db.AdministradorLinea.Get(id);
            if (administradorlinea == null)
            {
                return HttpNotFound();
            }
            return View(administradorlinea);
        }

        // POST: /AdministradorLinea/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdministradorLinea administradorlinea = db.AdministradorLinea.Get(id);
            db.AdministradorLinea.Delete(administradorlinea);
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
