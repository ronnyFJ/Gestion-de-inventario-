using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gestion_de_inventario_;

namespace Gestion_de_inventario_.Controllers
{
    [Authorize]
    public class AlmacenesController : Controller
    {
        private GESTION_INVENTARIOEntities db = new GESTION_INVENTARIOEntities();

        // GET: Almacenes
        /*public ActionResult Index()
        {
            var almacenes = db.Almacenes.Include(a => a.Existencias_Por_Almacen);
            return View(almacenes.ToList());
        }*/

        // GET: Almacenes/Details/5
        [Authorize(Roles = "Administrador, Consulta")]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Almacenes almacenes = db.Almacenes.Find(id);
            if (almacenes == null)
            {
                return HttpNotFound();
            }
            return View(almacenes);
        }

        // GET: Almacenes/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            ViewBag.Id_Almacen = new SelectList(db.Existencias_Por_Almacen, "Id_Almacen", "Id_Articulo");
            return View();
        }

        // POST: Almacenes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Almacen,Descripcion,Estado")] Almacenes almacenes)
        {
            if (ModelState.IsValid)
            {
                db.Almacenes.Add(almacenes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Almacen = new SelectList(db.Existencias_Por_Almacen, "Id_Almacen", "Id_Articulo", almacenes.Id_Almacen);
            return View(almacenes);
        }

        // GET: Almacenes/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Almacenes almacenes = db.Almacenes.Find(id);
            if (almacenes == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Almacen = new SelectList(db.Existencias_Por_Almacen, "Id_Almacen", "Id_Articulo", almacenes.Id_Almacen);
            return View(almacenes);
        }

        // POST: Almacenes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Almacen,Descripcion,Estado")] Almacenes almacenes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(almacenes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Almacen = new SelectList(db.Existencias_Por_Almacen, "Id_Almacen", "Id_Articulo", almacenes.Id_Almacen);
            return View(almacenes);
        }

        // GET: Almacenes/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Almacenes almacenes = db.Almacenes.Find(id);
            if (almacenes == null)
            {
                return HttpNotFound();
            }
            return View(almacenes);
        }

        // POST: Almacenes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Almacenes almacenes = db.Almacenes.Find(id);
            db.Almacenes.Remove(almacenes);
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
        public ActionResult Index(string Criterio = null)
        {
            return View(db.Almacenes.Where(p => Criterio == null || p.Descripcion.StartsWith(Criterio)));
        }
    }
}
