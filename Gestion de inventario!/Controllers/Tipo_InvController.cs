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
    public class Tipo_InvController : Controller
    {
        private GESTION_INVENTARIOEntities db = new GESTION_INVENTARIOEntities();

        // GET: Tipo_Inv
        /* public ActionResult Index()
         {
             return View(db.Tipo_Inv.ToList());
         }*/

        // GET: Tipo_Inv/Details/5
        [Authorize(Roles = "Administrador, Consulta")]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Inv tipo_Inv = db.Tipo_Inv.Find(id);
            if (tipo_Inv == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Inv);
        }

        // GET: Tipo_Inv/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo_Inv/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Tipo_inv,Nombre,Descripcion,Estado")] Tipo_Inv tipo_Inv)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_Inv.Add(tipo_Inv);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_Inv);
        }

        // GET: Tipo_Inv/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Inv tipo_Inv = db.Tipo_Inv.Find(id);
            if (tipo_Inv == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Inv);
        }

        // POST: Tipo_Inv/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Tipo_inv,Nombre,Descripcion,Estado")] Tipo_Inv tipo_Inv)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_Inv).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_Inv);
        }

        // GET: Tipo_Inv/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Inv tipo_Inv = db.Tipo_Inv.Find(id);
            if (tipo_Inv == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Inv);
        }

        // POST: Tipo_Inv/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Tipo_Inv tipo_Inv = db.Tipo_Inv.Find(id);
            db.Tipo_Inv.Remove(tipo_Inv);
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
            return View(db.Tipo_Inv.Where(p => Criterio == null || p.Nombre.StartsWith(Criterio)));
        }
    }
}
