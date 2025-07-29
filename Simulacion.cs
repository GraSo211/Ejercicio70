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

            private float reloj { get; set; }
            private List<Evento> eventos { get; set; }

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
        }


            public void IniciarSimulacion()
            {
                for (int i = 1; i <= cantidadAlumnos; i++)
                {
                    Cliente cliente = new Cliente(i);
                    listaClientes.Add(cliente);

                }
                Cola colaAdjuntos = new Cola(1, "Cola_Profesores_Adjuntos");
                Cola colaTitular = new Cola(2, "Cola_Titular_Catedra");

                Profesor profesorAdjunto1 = new Profesor(1,"Adjunto_1", cola_adjuntos);
                Profesor profesorAdjunto2 = new Profesor(2, "Adjunto_2", cola_adjuntos);
                Profesor titularCatedra = new Profesor(3, "Titular_Catedra", cola_titular);
                
            }
        }                                                         
                 
    
    public struct Vector_Estado
    {
        public int id { get; set; }
        public string eventoActual { get; set; }
        public Vector_Estado() { }
    }
}                                                                 
                                                                  