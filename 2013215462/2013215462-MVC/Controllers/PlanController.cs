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
    public class PlanController : Controller
    {
        private readonly IUnityOfWork db;


        public PlanController()
        {

        }

        public PlanController(IUnityOfWork _db)
        {
            db = _db;
        }
        // GET: /Plan/
        public ActionResult Index()
        {
            return View(db.Plan.GetAll());
        }

        // GET: /Plan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = db.Plan.Get(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // GET: /Plan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Plan/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="PlanID,EvaluacionID")] Plan plan)
        {
            if (ModelState.IsValid)
            {
                db.Plan.add(plan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(plan);
        }

        // GET: /Plan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = db.Plan.Get(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // POST: /Plan/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="PlanID,EvaluacionID")] Plan plan)
        {
            if (ModelState.IsValid)
            {
                db.StateModified(plan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plan);
        }

        // GET: /Plan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = db.Plan.Get(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // POST: /Plan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Plan plan = db.Plan.Get(id);
            db.Plan.Delete(plan);
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
