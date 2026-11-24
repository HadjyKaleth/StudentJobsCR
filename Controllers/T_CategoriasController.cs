using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentJobsCR.Models;

namespace StudentJobsCR.Controllers
{
    public class T_CategoriasController : Controller
    {
        private BD_StudentJobsCREntities db = new BD_StudentJobsCREntities();

        // GET: T_Categorias
        public ActionResult Index()
        {
            return View(db.T_Categorias.ToList());
        }

        // GET: T_Categorias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Categorias t_Categorias = db.T_Categorias.Find(id);
            if (t_Categorias == null)
            {
                return HttpNotFound();
            }
            return View(t_Categorias);
        }

        // GET: T_Categorias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T_Categorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Categoria,Nombre_Categoria,Descripcion_Categoria")] T_Categorias t_Categorias)
        {
            if (ModelState.IsValid)
            {
                db.T_Categorias.Add(t_Categorias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_Categorias);
        }

        // GET: T_Categorias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Categorias t_Categorias = db.T_Categorias.Find(id);
            if (t_Categorias == null)
            {
                return HttpNotFound();
            }
            return View(t_Categorias);
        }

        // POST: T_Categorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Categoria,Nombre_Categoria,Descripcion_Categoria")] T_Categorias t_Categorias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Categorias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_Categorias);
        }

        // GET: T_Categorias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Categorias t_Categorias = db.T_Categorias.Find(id);
            if (t_Categorias == null)
            {
                return HttpNotFound();
            }
            return View(t_Categorias);
        }

        // POST: T_Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Categorias t_Categorias = db.T_Categorias.Find(id);
            db.T_Categorias.Remove(t_Categorias);
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
