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
    public class DepartamentoController : Controller
    {
        private readonly IUnityOfWork db;

        public DepartamentoController()
        {

        }

        public DepartamentoController(IUnityOfWork _db)
        {
            db = _db;
        }
        // GET: /Departamento/
        public ActionResult Index()
        {
            return View(db.Departamento.GetAll());
        }

        // GET: /Departamento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departamento departamento = db.Departamento.Get(id);
            if (departamento == null)
            {
                return HttpNotFound();
            }
            return View(departamento);
        }

        // GET: /Departamento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Departamento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="DepartamentoID,ProvinciaID")] Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                db.Departamento.add(departamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(departamento);
        }

        // GET: /Departamento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departamento departamento = db.Departamento.Get(id);
            if (departamento == null)
            {
                return HttpNotFound();
            }
            return View(departamento);
        }

        // POST: /Departamento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="DepartamentoID,ProvinciaID")] Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                db.StateModified(departamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(departamento);
        }

        // GET: /Departamento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departamento departamento = db.Departamento.Get(id);
            if (departamento == null)
            {
                return HttpNotFound();
            }
            return View(departamento);
        }

        // POST: /Departamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Departamento departamento = db.Departamento.Get(id);
            db.Departamento.Delete(departamento);
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
