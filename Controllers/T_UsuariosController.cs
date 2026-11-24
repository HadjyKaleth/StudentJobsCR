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
    public class T_UsuariosController : Controller
    {
        private BD_StudentJobsCREntities db = new BD_StudentJobsCREntities();

        // GET: T_Usuarios
        public ActionResult Index()
        {
            return View(db.T_Usuarios.ToList());
        }

        // GET: T_Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Usuarios t_Usuarios = db.T_Usuarios.Find(id);
            if (t_Usuarios == null)
            {
                return HttpNotFound();
            }
            return View(t_Usuarios);
        }

        // GET: T_Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T_Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cedula_Usuario,Nombre_Usuario,Email_Usuario,Password_Usuario,Rol_Usuario")] T_Usuarios t_Usuarios)
        {
            if (ModelState.IsValid)
            {
                // 🔥 FIX DEL ERROR DATETIME
                t_Usuarios.FechaRegistro_Usuario = DateTime.Now;

                db.T_Usuarios.Add(t_Usuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_Usuarios);
        }

        // GET: T_Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Usuarios t_Usuarios = db.T_Usuarios.Find(id);
            if (t_Usuarios == null)
            {
                return HttpNotFound();
            }
            return View(t_Usuarios);
        }

        // POST: T_Usuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Usuario,Cedula_Usuario,Nombre_Usuario,Email_Usuario,Password_Usuario,Rol_Usuario")] T_Usuarios t_Usuarios)
        {
            if (ModelState.IsValid)
            {
                // 🔥 FIX DEL ERROR DATETIME
                t_Usuarios.FechaRegistro_Usuario = DateTime.Now;

                db.Entry(t_Usuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_Usuarios);
        }

        // GET: T_Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Usuarios t_Usuarios = db.T_Usuarios.Find(id);
            if (t_Usuarios == null)
            {
                return HttpNotFound();
            }
            return View(t_Usuarios);
        }

        // POST: T_Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Usuarios t_Usuarios = db.T_Usuarios.Find(id);
            db.T_Usuarios.Remove(t_Usuarios);
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