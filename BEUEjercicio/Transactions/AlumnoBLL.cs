using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUEjercicio.Transactions
{
    public class AlumnoBLL
    {
        //BLL BUSSINESS LOGIC LAYER 
        public static Alumno Get(int? id)
        {
            Entities db = new Entities();
            return db.Alumnoes.Find(id);
        }

        public static void Create(Alumno alumno)
        {
            using(Entities db = new Entities())
            {
                using(var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Alumnoes.Add(alumno);
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static void Update(Alumno alumno)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Alumnoes.Attach(alumno);
                        db.Entry(alumno).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static void Delete(int? id)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Alumno alumno = db.Alumnoes.Find(id);
                        db.Entry(alumno).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static List<Alumno> List()
        {
            Entities db = new Entities(); //Instancia el contexto
            return db.Alumnoes.ToList(); //SQL -> SELECT * FROM dbo.Alumno}
            //Los metdos del EntityFramework se denomina Linq, y la evaluación de condiciones Lambda
        }

        private static List<Alumno> GetAlumnos(string criterio)
        {
            //Ejemplo: criterio = 'vela'
            //Posibles resultados => Vela, Velasco, Avelardo ...
            Entities db = new Entities(); //Instancia el contexto
            return db.Alumnoes.Where(x => x.apellidos.ToLower().Contains(criterio)).ToList(); //SQL -> SELECT * FROM dbo.Alumno}
            //Los metdos del EntityFramework se denomina Linq, y la evaluación de condiciones Lambda
        }

        private static Alumno GetAlumno(int? id)
        {
            Entities db = new Entities();
            return db.Alumnoes.FirstOrDefault(x => x.idalumno == id);
        }

        private static Alumno GetAlumno(string cedula)
        {
            Entities db = new Entities();
            return db.Alumnoes.FirstOrDefault(x => x.cedula == cedula);
        }
    }
}
