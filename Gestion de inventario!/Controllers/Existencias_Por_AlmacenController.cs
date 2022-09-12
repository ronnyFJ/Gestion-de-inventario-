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
    public class Existencias_Por_AlmacenController : Controller
    {
        private GESTION_INVENTARIOEntities db = new GESTION_INVENTARIOEntities();

        // GET: Existencias_Por_Almacen
        /* public ActionResult Index()
         {
             var existencias_Por_Almacen = db.Existencias_Por_Almacen.Include(e => e.Almacenes).Include(e => e.Articulo);
             return View(existencias_Por_Almacen.ToList());
         }*/

        // GET: Existencias_Por_Almacen/Details/5
        [Authorize(Roles = "Administrador, Consulta")]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Existencias_Por_Almacen existencias_Por_Almacen = db.Existencias_Por_Almacen.Find(id);
            if (existencias_Por_Almacen == null)
            {
                return HttpNotFound();
            }
            return View(existencias_Por_Almacen);
        }

        // GET: Existencias_Por_Almacen/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            ViewBag.Id_Almacen = new SelectList(db.Almacenes, "Id_Almacen", "Descripcion");
            ViewBag.Id_Articulo = new SelectList(db.Articulo, "Id_Articulo", "Descripcion");
            return View();
        }

        // POST: Existencias_Por_Almacen/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Almacen,Id_Articulo,Cantidad")] Existencias_Por_Almacen existencias_Por_Almacen)
        {
            if (ModelState.IsValid)
            {
                db.Existencias_Por_Almacen.Add(existencias_Por_Almacen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Almacen = new SelectList(db.Almacenes, "Id_Almacen", "Descripcion", existencias_Por_Almacen.Id_Almacen);
            ViewBag.Id_Articulo = new SelectList(db.Articulo, "Id_Articulo", "Descripcion", existencias_Por_Almacen.Id_Articulo);
            return View(existencias_Por_Almacen);
        }

        // GET: Existencias_Por_Almacen/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Existencias_Por_Almacen existencias_Por_Almacen = db.Existencias_Por_Almacen.Find(id);
            if (existencias_Por_Almacen == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Almacen = new SelectList(db.Almacenes, "Id_Almacen", "Descripcion", existencias_Por_Almacen.Id_Almacen);
            ViewBag.Id_Articulo = new SelectList(db.Articulo, "Id_Articulo", "Descripcion", existencias_Por_Almacen.Id_Articulo);
            return View(existencias_Por_Almacen);
        }

        // POST: Existencias_Por_Almacen/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Almacen,Id_Articulo,Cantidad")] Existencias_Por_Almacen existencias_Por_Almacen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(existencias_Por_Almacen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Almacen = new SelectList(db.Almacenes, "Id_Almacen", "Descripcion", existencias_Por_Almacen.Id_Almacen);
            ViewBag.Id_Articulo = new SelectList(db.Articulo, "Id_Articulo", "Descripcion", existencias_Por_Almacen.Id_Articulo);
            return View(existencias_Por_Almacen);
        }

        // GET: Existencias_Por_Almacen/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Existencias_Por_Almacen existencias_Por_Almacen = db.Existencias_Por_Almacen.Find(id);
            if (existencias_Por_Almacen == null)
            {
                return HttpNotFound();
            }
            return View(existencias_Por_Almacen);
        }

        // POST: Existencias_Por_Almacen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Existencias_Por_Almacen existencias_Por_Almacen = db.Existencias_Por_Almacen.Find(id);
            db.Existencias_Por_Almacen.Remove(existencias_Por_Almacen);
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
            return View(db.Existencias_Por_Almacen.Where(p => Criterio == null || p.Id_Articulo.StartsWith(Criterio)));
        }
    }
}
