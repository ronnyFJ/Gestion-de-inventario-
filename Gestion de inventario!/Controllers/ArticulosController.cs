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
    public class ArticulosController : Controller
    {
        private GESTION_INVENTARIOEntities db = new GESTION_INVENTARIOEntities();

        // GET: Articulos
        /*public ActionResult Index()
        {
            var articulo = db.Articulo.Include(a => a.Tipo_Inv);
            return View(articulo.ToList());
        }*/

        // GET: Articulos/Details/5
        [Authorize(Roles = "Administrador, Consulta")]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulo articulo = db.Articulo.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            return View(articulo);
        }

        // GET: Articulos/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            ViewBag.Id_Tipo_Inv = new SelectList(db.Tipo_Inv, "Id_Tipo_inv", "Nombre");
            return View();
        }

        // POST: Articulos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Articulo,Descripcion,Existencia,Id_Tipo_Inv,Costo_Unitario,Estados")] Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                db.Articulo.Add(articulo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Tipo_Inv = new SelectList(db.Tipo_Inv, "Id_Tipo_inv", "Nombre", articulo.Id_Tipo_Inv);
            return View(articulo);
        }

        // GET: Articulos/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulo articulo = db.Articulo.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Tipo_Inv = new SelectList(db.Tipo_Inv, "Id_Tipo_inv", "Nombre", articulo.Id_Tipo_Inv);
            return View(articulo);
        }

        // POST: Articulos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Articulo,Descripcion,Existencia,Id_Tipo_Inv,Costo_Unitario,Estados")] Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articulo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Tipo_Inv = new SelectList(db.Tipo_Inv, "Id_Tipo_inv", "Nombre", articulo.Id_Tipo_Inv);
            return View(articulo);
        }

        // GET: Articulos/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulo articulo = db.Articulo.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            return View(articulo);
        }

        // POST: Articulos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Articulo articulo = db.Articulo.Find(id);
            db.Articulo.Remove(articulo);
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
            return View(db.Articulo.Where(p => Criterio == null || p.Descripcion.StartsWith(Criterio)));
        }
    }
}
