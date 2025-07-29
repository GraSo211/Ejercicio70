using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio70
{
    internal class Cliente
    {
        int id { get; set; }
        string estado { get; set; }



        public Cliente(int id)
        {
            this.id = id;
            this.estado = "En_Examen";
        }

    }
}
