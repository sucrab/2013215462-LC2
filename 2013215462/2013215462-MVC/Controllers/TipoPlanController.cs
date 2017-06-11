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
    public class TipoPlanController : Controller
    {
        private readonly IUnityOfWork db;


        public TipoPlanController()
        {

        }
        public TipoPlanController(IUnityOfWork _db)
        {
            db = _db;
        }

        // GET: /TipoPlan/
        public ActionResult Index()
        {
            return View(db.TipoPlan.GetAll());
        }

        // GET: /TipoPlan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPlan tipoplan = db.TipoPlan.Get(id);
            if (tipoplan == null)
            {
                return HttpNotFound();
            }
            return View(tipoplan);
        }

        // GET: /TipoPlan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TipoPlan/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="TipoPlanID")] TipoPlan tipoplan)
        {
            if (ModelState.IsValid)
            {
                db.TipoPlan.add(tipoplan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoplan);
        }

        // GET: /TipoPlan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPlan tipoplan = db.TipoPlan.Get(id);
            if (tipoplan == null)
            {
                return HttpNotFound();
            }
            return View(tipoplan);
        }

        // POST: /TipoPlan/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="TipoPlanID")] TipoPlan tipoplan)
        {
            if (ModelState.IsValid)
            {
                db.StateModified(tipoplan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoplan);
        }

        // GET: /TipoPlan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPlan tipoplan = db.TipoPlan.Get(id);
            if (tipoplan == null)
            {
                return HttpNotFound();
            }
            return View(tipoplan);
        }

        // POST: /TipoPlan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoPlan tipoplan = db.TipoPlan.Get(id);
            db.TipoPlan.Delete(tipoplan);
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
