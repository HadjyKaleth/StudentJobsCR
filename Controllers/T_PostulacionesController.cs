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
    public class T_PostulacionesController : Controller
    {
        private BD_StudentJobsCREntities db = new BD_StudentJobsCREntities();

        // GET: T_Postulaciones
        public ActionResult Index()
        {
            var t_Postulaciones = db.T_Postulaciones.Include(t => t.T_Estudiantes).Include(t => t.T_Vacantes);
            return View(t_Postulaciones.ToList());
        }

        // GET: T_Postulaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Postulaciones t_Postulaciones = db.T_Postulaciones.Find(id);
            if (t_Postulaciones == null)
            {
                return HttpNotFound();
            }
            return View(t_Postulaciones);
        }

        // GET: T_Postulaciones/Create
        public ActionResult Create()
        {
            ViewBag.Id_Estudiante = new SelectList(db.T_Estudiantes, "Id_Estudiante", "Cedula_Estudiante");
            ViewBag.Id_Vacante = new SelectList(db.T_Vacantes, "Id_Vacante", "Titulo_Vacante");
            return View();
        }

        // POST: T_Postulaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Postulacion,FechaPostulacion,Estado_Postulacion,Nota_Postulacion,Id_Estudiante,Id_Vacante")] T_Postulaciones t_Postulaciones)
        {
            if (ModelState.IsValid)
            {
                db.T_Postulaciones.Add(t_Postulaciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Estudiante = new SelectList(db.T_Estudiantes, "Id_Estudiante", "Cedula_Estudiante", t_Postulaciones.Id_Estudiante);
            ViewBag.Id_Vacante = new SelectList(db.T_Vacantes, "Id_Vacante", "Titulo_Vacante", t_Postulaciones.Id_Vacante);
            return View(t_Postulaciones);
        }

        // GET: T_Postulaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Postulaciones t_Postulaciones = db.T_Postulaciones.Find(id);
            if (t_Postulaciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Estudiante = new SelectList(db.T_Estudiantes, "Id_Estudiante", "Cedula_Estudiante", t_Postulaciones.Id_Estudiante);
            ViewBag.Id_Vacante = new SelectList(db.T_Vacantes, "Id_Vacante", "Titulo_Vacante", t_Postulaciones.Id_Vacante);
            return View(t_Postulaciones);
        }

        // POST: T_Postulaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Postulacion,FechaPostulacion,Estado_Postulacion,Nota_Postulacion,Id_Estudiante,Id_Vacante")] T_Postulaciones t_Postulaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Postulaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Estudiante = new SelectList(db.T_Estudiantes, "Id_Estudiante", "Cedula_Estudiante", t_Postulaciones.Id_Estudiante);
            ViewBag.Id_Vacante = new SelectList(db.T_Vacantes, "Id_Vacante", "Titulo_Vacante", t_Postulaciones.Id_Vacante);
            return View(t_Postulaciones);
        }

        // GET: T_Postulaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Postulaciones t_Postulaciones = db.T_Postulaciones.Find(id);
            if (t_Postulaciones == null)
            {
                return HttpNotFound();
            }
            return View(t_Postulaciones);
        }

        // POST: T_Postulaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Postulaciones t_Postulaciones = db.T_Postulaciones.Find(id);
            db.T_Postulaciones.Remove(t_Postulaciones);
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
