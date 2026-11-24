using System;
using System.Linq;
using System.Web.Mvc;
using StudentJobsCR;
using StudentJobsCR.Models;

namespace StudentJobsCR.Controllers
{
    public class AuthController : Controller
    {
        private BD_StudentJobsCREntities db = new BD_StudentJobsCREntities();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string correo, string contrasena)
        {
            var usuario = db.T_Usuarios.FirstOrDefault(u => u.Email_Usuario == correo && u.Password_Usuario == contrasena);

            if (usuario != null)
            {
                Session["IdUsuario"] = usuario.Id_Usuario;
                Session["Nombre"] = usuario.Nombre_Usuario;
                Session["Rol"] = usuario.Rol_Usuario;
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Correo o contrasena incorrectos";
            return View();
        }

        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registro(RegistroViewModel model)
        {
            try
            {
                var usuario = new T_Usuarios
                {
                    Cedula_Usuario = model.Cedula_Usuario,
                    Nombre_Usuario = model.Nombre_Usuario,
                    Email_Usuario = model.Email_Usuario,
                    Password_Usuario = model.Password_Usuario,
                    Rol_Usuario = model.Rol_Usuario,
                    FechaRegistro_Usuario = DateTime.Now
                };

                db.T_Usuarios.Add(usuario);
                db.SaveChanges();

                if (model.Rol_Usuario == "Estudiante")
                {
                    var estudiante = new T_Estudiantes
                    {
                        Cedula_Estudiante = model.Cedula_Usuario,
                        Nombre_Estudiante = model.Nombre_Usuario,
                        Universidad_Estudiante = model.Universidad_Estudiante ?? "N/A",
                        Carrera_Estudiante = model.Carrera_Estudiante ?? "N/A",
                        AnioAcademico_Estudiante = model.AnioAcademico_Estudiante ?? 1,
                        Disponibilidad_Estudiante = model.Disponibilidad_Estudiante ?? "N/A",
                        Id_Usuario = usuario.Id_Usuario
                    };

                    db.T_Estudiantes.Add(estudiante);
                }
                else if (model.Rol_Usuario == "Empresa")
                {
                    var empresa = new T_Empresas
                    {
                        CedulaJuridica_Empresa = model.CedulaJuridica_Empresa ?? "TEMP",
                        Nombre_Empresa = model.Nombre_Empresa ?? model.Nombre_Usuario,
                        Email_Empresa = model.Email_Empresa ?? model.Email_Usuario,
                        Id_Usuario = usuario.Id_Usuario
                    };

                    db.T_Empresas.Add(empresa);
                }

                db.SaveChanges();

                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(model);
            }
        }

        public ActionResult CerrarSesion()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}