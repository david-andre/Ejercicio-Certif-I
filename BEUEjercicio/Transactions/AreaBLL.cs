using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUEjercicio.Transactions
{
    public class AreaBLL
    {
        public static List<Area> List()
        {
            Entities db = new Entities(); //Instancia el contexto
            return db.Areas.ToList(); //SQL -> SELECT * FROM dbo.Alumno}
            //Los metdos del EntityFramework se denomina Linq, y la evaluación de condiciones Lambda
        }

    }
}
