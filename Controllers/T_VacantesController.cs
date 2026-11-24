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
    public class T_VacantesController : Controller
    {
        private BD_StudentJobsCREntities db = new BD_StudentJobsCREntities();

        // GET: T_Vacantes
        public ActionResult Index()
        {
            var t_Vacantes = db.T_Vacantes.Include(t => t.T_Categorias).Include(t => t.T_Empresas);
            return View(t_Vacantes.ToList());
        }

        // GET: T_Vacantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Vacantes t_Vacantes = db.T_Vacantes.Find(id);
            if (t_Vacantes == null)
            {
                return HttpNotFound();
            }
            return View(t_Vacantes);
        }

        // GET: T_Vacantes/Create
        public ActionResult Create()
        {
            ViewBag.Id_Categoria = new SelectList(db.T_Categorias, "Id_Categoria", "Nombre_Categoria");
            ViewBag.Id_Empresa = new SelectList(db.T_Empresas, "Id_Empresa", "CedulaJuridica_Empresa");
            return View();
        }

        // POST: T_Vacantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Vacante,Titulo_Vacante,Descripcion_Vacante,Requisitos_Vacante,Salario_Vacante,Modalidad_Vacante,Horario_Vacante,FechaPublicacion_Vacante,FechaCierre_Vacante,Id_Empresa,Id_Categoria")] T_Vacantes t_Vacantes)
        {
            if (ModelState.IsValid)
            {
                db.T_Vacantes.Add(t_Vacantes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Categoria = new SelectList(db.T_Categorias, "Id_Categoria", "Nombre_Categoria", t_Vacantes.Id_Categoria);
            ViewBag.Id_Empresa = new SelectList(db.T_Empresas, "Id_Empresa", "CedulaJuridica_Empresa", t_Vacantes.Id_Empresa);
            return View(t_Vacantes);
        }

        // GET: T_Vacantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Vacantes t_Vacantes = db.T_Vacantes.Find(id);
            if (t_Vacantes == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Categoria = new SelectList(db.T_Categorias, "Id_Categoria", "Nombre_Categoria", t_Vacantes.Id_Categoria);
            ViewBag.Id_Empresa = new SelectList(db.T_Empresas, "Id_Empresa", "CedulaJuridica_Empresa", t_Vacantes.Id_Empresa);
            return View(t_Vacantes);
        }

        // POST: T_Vacantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Vacante,Titulo_Vacante,Descripcion_Vacante,Requisitos_Vacante,Salario_Vacante,Modalidad_Vacante,Horario_Vacante,FechaPublicacion_Vacante,FechaCierre_Vacante,Id_Empresa,Id_Categoria")] T_Vacantes t_Vacantes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Vacantes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Categoria = new SelectList(db.T_Categorias, "Id_Categoria", "Nombre_Categoria", t_Vacantes.Id_Categoria);
            ViewBag.Id_Empresa = new SelectList(db.T_Empresas, "Id_Empresa", "CedulaJuridica_Empresa", t_Vacantes.Id_Empresa);
            return View(t_Vacantes);
        }

        // GET: T_Vacantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Vacantes t_Vacantes = db.T_Vacantes.Find(id);
            if (t_Vacantes == null)
            {
                return HttpNotFound();
            }
            return View(t_Vacantes);
        }

        // POST: T_Vacantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Vacantes t_Vacantes = db.T_Vacantes.Find(id);
            db.T_Vacantes.Remove(t_Vacantes);
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
