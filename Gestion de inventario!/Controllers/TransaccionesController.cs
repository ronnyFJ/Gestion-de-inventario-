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
    public class TransaccionesController : Controller
    {
        private GESTION_INVENTARIOEntities db = new GESTION_INVENTARIOEntities();

        // GET: Transacciones
        /*public ActionResult Index()
        {
            var transacciones = db.Transacciones.Include(t => t.Articulo);
            return View(transacciones.ToList());
        }*/

        // GET: Transacciones/Details/5
        [Authorize(Roles = "Administrador, Consulta")]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transacciones transacciones = db.Transacciones.Find(id);
            if (transacciones == null)
            {
                return HttpNotFound();
            }
            return View(transacciones);
        }

        // GET: Transacciones/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            ViewBag.Id_Articulo = new SelectList(db.Articulo, "Id_Articulo", "Descripcion");
            return View();
        }

        // POST: Transacciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Transaccion,Tipo_Transaccion,Id_Articulo,Fecha,Cantidad,Monto")] Transacciones transacciones)
        {
            if (ModelState.IsValid)
            {
                db.Transacciones.Add(transacciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Articulo = new SelectList(db.Articulo, "Id_Articulo", "Descripcion", transacciones.Id_Articulo);
            return View(transacciones);
        }

        // GET: Transacciones/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transacciones transacciones = db.Transacciones.Find(id);
            if (transacciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Articulo = new SelectList(db.Articulo, "Id_Articulo", "Descripcion", transacciones.Id_Articulo);
            return View(transacciones);
        }

        // POST: Transacciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Transaccion,Tipo_Transaccion,Id_Articulo,Fecha,Cantidad,Monto")] Transacciones transacciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transacciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Articulo = new SelectList(db.Articulo, "Id_Articulo", "Descripcion", transacciones.Id_Articulo);
            return View(transacciones);
        }

        // GET: Transacciones/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transacciones transacciones = db.Transacciones.Find(id);
            if (transacciones == null)
            {
                return HttpNotFound();
            }
            return View(transacciones);
        }

        // POST: Transacciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Transacciones transacciones = db.Transacciones.Find(id);
            db.Transacciones.Remove(transacciones);
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
            return View(db.Transacciones.Where(p => Criterio == null || p.Id_Articulo.StartsWith(Criterio)));
        }
    }
}
