using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio70
{
    internal class Simulacion
        {
            private int cantidadAlumnos { get; set; }
            private float finPartePractica { get; set; }
            private float finCorreccionPartePracticaA { get; set; }
            private float finCorreccionPartePracticaB { get; set; }
            private float finCorreccionParteTeorica { get; set; }
            private float porcAprobacionPract { get; set; }
            private float porcAprobacionTeo { get; set; }
            private int horaFinPract { get; set; }
            private int horaFinExamen { get; set; }

            private List<Cliente> listaClientes { get; set; }

        public Simulacion(int cantidadAlumnos, float finPartePractica, float finCorreccionPartePracticaA, float finCorreccionPartePracticaB, float finCorreccionParteTeorica, float porcAprobacionPract, float porcAprobacionTeo, int horaFinPract, int horaFinExamen)
            {
                this.cantidadAlumnos = cantidadAlumnos;
                this.finPartePractica = finPartePractica;
                this.finCorreccionPartePracticaA = finCorreccionPartePracticaA;
                this.finCorreccionPartePracticaB = finCorreccionPartePracticaB;
                this.finCorreccionParteTeorica = finCorreccionParteTeorica;
                this.porcAprobacionPract = porcAprobacionPract;
                this.porcAprobacionTeo = porcAprobacionTeo;
                this.horaFinPract = horaFinPract;
                this.horaFinExamen = horaFinExamen;
                this.listaClientes = new List<Cliente>();


        }


            public void IniciarSimulacion()
            {
                System.Diagnostics.Debug.WriteLine($"Cantidad de Alumnos: {cantidadAlumnos}");

            for (int i =1; i<=cantidadAlumnos; i++)
            {
                Cliente cliente= new Cliente(i);
                listaClientes.Add(cliente);

            }

        }
    
}
