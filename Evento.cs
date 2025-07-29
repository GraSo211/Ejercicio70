using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio70
{
    internal class Evento
    {
        string distribucion { get; set; }
        float tiempoLlegada { get; set; }
        float tiempoFin { get; set; }
        Cliente cliente { get; set; }
        Profesor profesor{ get; set; }
            
    }
}
