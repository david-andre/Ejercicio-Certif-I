using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUEjercicio.Transactions
{
    class AlumnoTBLL
    {
        //TBLL TRANSACTIONAL BUSSINESS LOGIC LAYER (TRANSACCIONES - ESCRITURA)
        private Entities context;
        public Alumno alumno { get; set; } //Alumno activo

        public AlumnoTBLL( bool withContext)
        {
            if(withContext)
            {
                context = new Entities();
            }
        }

        public void Get(int id)
        {
            alumno = context.Alumnoes.Find(id);
        }

        public void Create(Alumno a)
        {
            using(Entities db = new Entities())
            {
                using(var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Alumnoes.Add(a);
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

        public void Update()
        {
            using(var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Entry(alumno).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public void Delete()
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Entry(alumno).State = System.Data.Entity.EntityState.Deleted;
                    context.SaveChanges();
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
}
