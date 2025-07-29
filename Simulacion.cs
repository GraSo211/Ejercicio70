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
            private Profesor adjunto1 { get; set; }
            private Profesor adjunto2 { get; set; }
            private Profesor titularCatedra { get; set; }
            private Cola colaAdjuntos { get; set; }
            private Cola colaTitular { get; set; }
            private float acumTiempoTotalExamenAlumnosAprobados { get; set; }
            private int contAlumnosAprobados { get; set; }
            private List<Cliente> listaClientes { get; set; }
            private List<Evento> eventos { get; set; }
            

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


                this.reloj = horaFinPract;
                
                this.colaAdjuntos = new Cola(1, "Cola_Profesores_Adjuntos");
                this.colaTitular = new Cola(2, "Cola_Titular_Catedra");
                this.adjunto1 = new Profesor(1, "Adjunto_1", colaAdjuntos);
                this.adjunto2 = new Profesor(2, "Adjunto_2", colaAdjuntos);
                this.titularCatedra = new Profesor(3, "Titular_Catedra", colaTitular);
                this.acumTiempoTotalExamenAlumnosAprobados = 0;
                this.contAlumnosAprobados = 0;
                this.listaClientes = new List<Cliente>();
                this.eventos = new List<Evento>();
        }


            public void IniciarSimulacion()
            {
                for (int i = 1; i <= cantidadAlumnos; i++)
                {
                    Cliente cliente = new Cliente(i);
                    listaClientes.Add(cliente);

                }
                
                
            }
        }                                                         
                 
    
    public struct Vector_Estado
    {
        private int id { get; set; }
        private string eventoActual { get; set; }
        private float reloj { get; set; }
        private Evento finPartePractica { get; set; }
        private Evento finCorreccionPartePracticaAdjunto1 { get; set; }
        private Evento finCorreccionPartePracticaAdjunto2 { get; set; }
        private Evento finCorreccionParteTeorica { get; set; }
        private Evento finExamen { get; set; }
        private Profesor  adjunto1 { get; set; }
        private Profesor adjunto2 { get; set; }
        private Profesor titularCatedra { get; set; }
        private Cola colaAdjuntos { get; set; }
        private Cola colaTitular { get; set; }

        public Vector_Estado() { }
    }
}                                                                 
                                                                  