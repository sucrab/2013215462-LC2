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
    public class AdministradorEquipoController : Controller
    {
        //private DiazDbContext db = new DiazDbContext();
        private readonly IUnityOfWork _UnityOfWork;

        public AdministradorEquipoController()
        {

        }

        public AdministradorEquipoController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        // GET: /AdministradorEquipo/
        public ActionResult Index()
        {
            return View(_UnityOfWork.AdministradorEquipo.GetAll());
        }

        // GET: /AdministradorEquipo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdministradorEquipo administradorequipo = _UnityOfWork.AdministradorEquipo.Get(id);
            if (administradorequipo == null)
            {
                return HttpNotFound();
            }
            return View(administradorequipo);
        }

        // GET: /AdministradorEquipo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /AdministradorEquipo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="AdministradorEquipoID")] AdministradorEquipo administradorequipo)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.AdministradorEquipo.add(administradorequipo);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(administradorequipo);
        }

        // GET: /AdministradorEquipo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdministradorEquipo administradorequipo = _UnityOfWork.AdministradorEquipo.Get(id);
            if (administradorequipo == null)
            {
                return HttpNotFound();
            }
            return View(administradorequipo);
        }

        // POST: /AdministradorEquipo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="AdministradorEquipoID")] AdministradorEquipo administradorequipo)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(administradorequipo);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(administradorequipo);
        }

        // GET: /AdministradorEquipo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdministradorEquipo administradorequipo = _UnityOfWork.AdministradorEquipo.Get(id);
            if (administradorequipo == null)
            {
                return HttpNotFound();
            }
            return View(administradorequipo);
        }

        // POST: /AdministradorEquipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdministradorEquipo actor = _UnityOfWork.AdministradorEquipo.Get(id);
            _UnityOfWork.AdministradorEquipo.Delete(actor);
            _UnityOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
