using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio70
{
    internal class Alumno
    {
        int id { get; set; }
        public string estado { get; set; }



        public Alumno(int id)
        {
            this.id = id;
            this.estado = "En_Examen";
        }

    }
}
