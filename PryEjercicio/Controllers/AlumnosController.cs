using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BEUEjercicio;
using BEUEjercicio.Transactions;

namespace PryEjercicio.Controllers
{
    public class AlumnosController : Controller
    {
        // GET: Alumnos
        public ActionResult Index()
        {
            //return View("Index", AlumnoBLL.List()); Ejemplo con el método View sobrecargado
            //1er parametro Nombre de la vista, 2do el modelo
            //ViewBag.Title = "Listado de Alumnos"; Viebag me permite enviar contenido del controlador a la vista
            return View(AlumnoBLL.List());
        }

        // GET: Alumnos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); //Petición equivocada
            }
            Alumno alumno = AlumnoBLL.Get(id);
            if (alumno == null)
            {
                return HttpNotFound(); //Alumno no Encontrado
            }
            return View(alumno); //Vista + modelo
        }

        // GET: Alumnos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alumnos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idalumno,nombre,apellidos,cedula,fecha_nacimiento,lugar_nacimiento,sexo")] Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                AlumnoBLL.Create(alumno);
                return RedirectToAction("Index");
            }

            return View(alumno);
        }

        // GET: Alumnos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumno alumno = AlumnoBLL.Get(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View(alumno);
        }

        // POST: Alumnos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idalumno,nombre,apellidos,cedula,fecha_nacimiento,lugar_nacimiento,sexo")] Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                AlumnoBLL.Update(alumno);
                return RedirectToAction("Index");
            }
            return View(alumno);
        }

        // GET: Alumnos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumno alumno = AlumnoBLL.Get(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View(alumno);
        }

        // POST: Alumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AlumnoBLL.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
