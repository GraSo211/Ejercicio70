using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio70
{
    internal class Cola
    {
        int id { get; set; }
        string nombre { get; set; }
        List<Cliente> clientes { get; set; }

        public Cola(int id, string nombre) {
            this.id = id;
            this.nombre = nombre;
            this.clientes = new List<Cliente>();
        }

    }

}
