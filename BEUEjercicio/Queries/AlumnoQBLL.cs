using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BEUEjercicio.Queries
{
    public static class AlumnoQBLL
    {
        //QBLL QUERY BUSSINESS LOGIC LAYER (LECTURA - CONSULTAS)

        public static List<Alumno> GetAlumnos()
        {
            Entities db = new Entities(); //Instancia el contexto
            return db.Alumnoes.ToList(); //SQL -> SELECT * FROM dbo.Alumno}
            //Los metdos del EntityFramework se denomina Linq, y la evaluación de condiciones Lambda
        }

        public static List<Alumno> GetAlumnos(string criterio)
        {
            //Ejemplo: criterio = 'vela'
            //Posibles resultados => Vela, Velasco, Avelardo ...
            Entities db = new Entities(); //Instancia el contexto
            return db.Alumnoes.Where(x => x.apellidos.ToLower().Contains(criterio)).ToList(); //SQL -> SELECT * FROM dbo.Alumno}
            //Los metdos del EntityFramework se denomina Linq, y la evaluación de condiciones Lambda
        }

        public static Alumno GetAlumno(int id)
        {
            Entities db = new Entities();
            return db.Alumnoes.FirstOrDefault(x => x.idalumno == id);
        }

        public static Alumno GetAlumno(string cedula)
        {
            Entities db = new Entities();
            return db.Alumnoes.FirstOrDefault(x => x.cedula == cedula);
        }



    }
}
