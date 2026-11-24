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
    public class T_EstudiantesController : Controller
    {
        private BD_StudentJobsCREntities db = new BD_StudentJobsCREntities();

        // GET: T_Estudiantes
        public ActionResult Index()
        {
            var t_Estudiantes = db.T_Estudiantes.Include(t => t.T_Usuarios);
            return View(t_Estudiantes.ToList());
        }

        // GET: T_Estudiantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Estudiantes t_Estudiantes = db.T_Estudiantes.Find(id);
            if (t_Estudiantes == null)
            {
                return HttpNotFound();
            }
            return View(t_Estudiantes);
        }

        // GET: T_Estudiantes/Create
        public ActionResult Create()
        {
            ViewBag.Id_Usuario = new SelectList(db.T_Usuarios, "Id_Usuario", "Cedula_Usuario");
            return View();
        }

        // POST: T_Estudiantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Estudiante,Cedula_Estudiante,Nombre_Estudiante,FechaNacimiento_Estudiante,Telefono_Estudiante,Universidad_Estudiante,Carrera_Estudiante,AnioAcademico_Estudiante,Disponibilidad_Estudiante,Habilidades_Estudiante,Id_Usuario")] T_Estudiantes t_Estudiantes)
        {
            if (ModelState.IsValid)
            {
                db.T_Estudiantes.Add(t_Estudiantes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Usuario = new SelectList(db.T_Usuarios, "Id_Usuario", "Cedula_Usuario", t_Estudiantes.Id_Usuario);
            return View(t_Estudiantes);
        }

        // GET: T_Estudiantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Estudiantes t_Estudiantes = db.T_Estudiantes.Find(id);
            if (t_Estudiantes == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Usuario = new SelectList(db.T_Usuarios, "Id_Usuario", "Cedula_Usuario", t_Estudiantes.Id_Usuario);
            return View(t_Estudiantes);
        }

        // POST: T_Estudiantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Estudiante,Cedula_Estudiante,Nombre_Estudiante,FechaNacimiento_Estudiante,Telefono_Estudiante,Universidad_Estudiante,Carrera_Estudiante,AnioAcademico_Estudiante,Disponibilidad_Estudiante,Habilidades_Estudiante,Id_Usuario")] T_Estudiantes t_Estudiantes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Estudiantes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Usuario = new SelectList(db.T_Usuarios, "Id_Usuario", "Cedula_Usuario", t_Estudiantes.Id_Usuario);
            return View(t_Estudiantes);
        }

        // GET: T_Estudiantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Estudiantes t_Estudiantes = db.T_Estudiantes.Find(id);
            if (t_Estudiantes == null)
            {
                return HttpNotFound();
            }
            return View(t_Estudiantes);
        }

        // POST: T_Estudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Estudiantes t_Estudiantes = db.T_Estudiantes.Find(id);
            db.T_Estudiantes.Remove(t_Estudiantes);
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
