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
    public class EquipoCelularController : Controller
    {
        private readonly IUnityOfWork db;

      
        public EquipoCelularController()
        {

        }
        public EquipoCelularController(IUnityOfWork _db)
        {
            db = _db;
        }
        // GET: /EquipoCelular/
        public ActionResult Index()
        {
            //var equipocelular = db.EquipoCelular.Include(e => e.AdministradorEquipo);
            return View(db.EquipoCelular.GetAll());
        }

        // GET: /EquipoCelular/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoCelular equipocelular = db.EquipoCelular.Get(id);
            if (equipocelular == null)
            {
                return HttpNotFound();
            }
            return View(equipocelular);
        }

        // GET: /EquipoCelular/Create
        public ActionResult Create()
        {
            ViewBag.AdministradorEquipoID = new SelectList(db.AdministradorEquipo.GetAll(), "AdministradorEquipoID", "AdministradorEquipoID");
            return View();
        }

        // POST: /EquipoCelular/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="EquipoCelularID,AdministradorEquipoID,EvaluacionID")] EquipoCelular equipocelular)
        {
            if (ModelState.IsValid)
            {
                db.EquipoCelular.add(equipocelular);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AdministradorEquipoID = new SelectList(db.AdministradorEquipo.GetAll(), "AdministradorEquipoID", "AdministradorEquipoID", equipocelular.AdministradorEquipoID);
            return View(equipocelular);
        }

        // GET: /EquipoCelular/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoCelular equipocelular = db.EquipoCelular.Get(id);
            if (equipocelular == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdministradorEquipoID = new SelectList(db.AdministradorEquipo.GetAll(), "AdministradorEquipoID", "AdministradorEquipoID", equipocelular.AdministradorEquipoID);
            return View(equipocelular);
        }

        // POST: /EquipoCelular/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="EquipoCelularID,AdministradorEquipoID,EvaluacionID")] EquipoCelular equipocelular)
        {
            if (ModelState.IsValid)
            {
                db.StateModified(equipocelular);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdministradorEquipoID = new SelectList(db.AdministradorEquipo.GetAll(), "AdministradorEquipoID", "AdministradorEquipoID", equipocelular.AdministradorEquipoID);
            return View(equipocelular);
        }

        // GET: /EquipoCelular/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoCelular equipocelular = db.EquipoCelular.Get(id);
            if (equipocelular == null)
            {
                return HttpNotFound();
            }
            return View(equipocelular);
        }

        // POST: /EquipoCelular/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EquipoCelular equipocelular = db.EquipoCelular.Get(id);
            db.EquipoCelular.Delete(equipocelular);
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
