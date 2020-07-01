using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUEjercicio.Transactions
{
    public class MatriculaBLL
    {
        public static Matricula Get(int? id)
        {
            Entities db = new Entities();
            return db.Matriculas.Find(id);
        }

        public static void Create(Matricula matricula)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Materia materia = db.Materias.Find(matricula.idmateria);
                        Config(matricula, materia);
                        db.Matriculas.Add(matricula);
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

        private static void Config(Matricula matricula, Materia materia)
        {      
            matricula.fecha = DateTime.Now;
            matricula.estado = "1"; //Creada
            if (matricula.tipo.Equals("P"))
            {
                matricula.costo = 0;
            }
            else if (matricula.tipo.Equals("S"))
            {
                matricula.costo = (decimal)(12.25 * materia.creditos);
            }
            else
            {
                matricula.costo = (decimal)(24.50 * materia.creditos);
            }
        }

        public static void Update(Matricula matricula)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Materia materia = db.Materias.Find(matricula.idmateria);
                        Config(matricula, materia);
                        db.Matriculas.Attach(matricula);
                        db.Entry(matricula).State = System.Data.Entity.EntityState.Modified;
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
                        Matricula matricula = db.Matriculas.Find(id);
                        db.Entry(matricula).State = System.Data.Entity.EntityState.Deleted;
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

        public static List<Matricula> List()
        {
            Entities db = new Entities(); //Instancia el contexto
            return db.Matriculas.ToList(); //SQL -> SELECT * FROM dbo.Alumno}
            //Los metdos del EntityFramework se denomina Linq, y la evaluación de condiciones Lambda
        }
    }
}

