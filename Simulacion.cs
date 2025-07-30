using System;
using System.Globalization;
using System.Text;
using CsvHelper;

using System.IO;
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
            

            private List<VectorEstado> listaVectoresEstado { get; set; }


            private float reloj { get; set; }
            private Profesor adjunto1 { get; set; }
            private Profesor adjunto2 { get; set; }
            private Profesor titularCatedra { get; set; }
            private Cola colaAdjuntos { get; set; }
            private Cola colaTitular { get; set; }
            private float acumTiempoTotalExamenAlumnosAprobados { get; set; }
            private int contAlumnosAprobados { get; set; }
            private List<Alumno> listaAlumnos { get; set; }
            private List<Evento> colaEventos { get; set; }

            private Evento eventoActual { get; set; }


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

                
                this.listaVectoresEstado = new List<VectorEstado>();



            this.reloj = horaFinPract;    
                this.colaAdjuntos = new Cola(1, "Cola_Profesores_Adjuntos");
                this.colaTitular = new Cola(2, "Cola_Titular_Catedra");
                this.adjunto1 = new Profesor(1, "Adjunto_1", colaAdjuntos);
                this.adjunto2 = new Profesor(2, "Adjunto_2", colaAdjuntos);
                this.titularCatedra = new Profesor(3, "Titular_Catedra", colaTitular);
                this.acumTiempoTotalExamenAlumnosAprobados = 0;
                this.contAlumnosAprobados = 0;
                this.listaAlumnos = new List<Alumno>();
                this.colaEventos = new List<Evento>();
        }


            public void Simular()
            {
                for (int i = 1; i <= cantidadAlumnos; i++)
                {
                    Alumno Alumno = new Alumno(i);
                    listaAlumnos.Add(Alumno);

                }
            
            int idVectorEstado = 1;
            VectorEstado vectorEstado = new VectorEstado(idVectorEstado++, "init", reloj.ToString(),"","","","","","","","","","","","","","","","",adjunto1.estado,adjunto2.estado,colaAdjuntos.Alumnos.Count.ToString(),titularCatedra.estado,colaTitular.Alumnos.Count.ToString(),acumTiempoTotalExamenAlumnosAprobados.ToString(),contAlumnosAprobados.ToString(),listaAlumnos);
            Evento eventoFinPartePractica = new FinPartePractica(reloj, listaAlumnos[0], titularCatedra);
            eventoFinPartePractica.GenerarEvento(ref vectorEstado, finPartePractica);
            
            
            colaEventos.Add(eventoFinPartePractica);

            float eventoMenorTiempo = reloj;
            while (idVectorEstado <10 )
            {
                // Comienza el sistema
                // Comenzamos revisando cual es el evento que hay que resolver, para ello buscamos el que suceda mas proximo al reloj actual

                foreach (Evento i in colaEventos)
                {
                    if (i.reloj >= eventoMenorTiempo) 
                    { 
                        eventoMenorTiempo = i.reloj;
                        eventoActual = i;
                    }
                }

                // Resolvemos el evento actual
                eventoActual.ResolverEvento(ref vectorEstado);
                listaVectoresEstado.Add(vectorEstado);

                idVectorEstado++;
            }



            string ruta = "E:\\Proyectos\\sim_final_tp\\ResultadosSimulacion.csv";

            List<string> csv = new List<string>();
            string header = ",,FIN_DE_PARTE_PRACTICA,,,FIN_CORRECCION_ADJUNTO_1,,,FIN_CORRECCION_ADJUNTO_2,,,APROBACION_PARTE_PRACTICA,,FIN_CORRECCION_PARTE_TEORICA,,APROBACION_PARTE_TEORICA,,FIN_DE_EXAMEN,ADJUNTO_1,ADJUNTO_2,,TITULAR_CATEDRA,,ACUM_TIEMPO_EXAMEN_ALUMNOS_APROBADOS,CONT_APROBADOS";
            string subHeader = "EVENTO,RELOJ,RND,TIEMPO,FIN_PARTE_PRACTICA,RND,TIEMPO,FIN_CORRECCION,RND,TIEMPO,FIN_CORRECCION,RND,ESTADO,TIEMPO,FIN_PARTE_TEORICA,RND,ESTADO,HORA,ESTADO,ESTADO,COLA_PROFESORES,ESTADO,COLA_TITULAR,, ";
            for (int i=1; i<= cantidadAlumnos;i++)
            {
                header += ", ALUMNO_"+i;
                subHeader += ",ESTADO";
            }
            csv.Add(header);
            csv.Add(subHeader);

            foreach(VectorEstado vE in listaVectoresEstado)
            {
                
            }
            File.WriteAllLines(ruta,csv,Encoding.UTF8);









        }
        }                                                         
                 
    
    internal struct VectorEstado
    {
        public int id { get; set; }
        public string eventoActual { get; set; }
        public string reloj { get; set; }
        public string rndfinPartePractica { get; set; }
        public string tiempofinPartePractica { get; set; }
        public string finfinPartePractica { get; set; }
        public string rndfinCorreccionPartePracticaAdjunto1 { get; set; }
        public string tiempofinCorreccionPartePracticaAdjunto1 { get; set; }
        public string finfinCorreccionPartePracticaAdjunto1 { get; set; }
        public string rndfinCorreccionPartePracticaAdjunto2 { get; set; }
        public string tiempoCorreccionPartePracticaAdjunto2 { get; set; }
        public string finfinCorreccionPartePracticaAdjunto2 { get; set; }
        public string rndAprobacionPartePractica { get; set; }
        public string estadoAprobacionPartePractica { get; set; }
        public string tiempofinCorreccionParteTeorica { get; set; }
        public string finfinCorreccionParteTeorica { get; set; }
        public string rndAprobacionParteTeorica { get; set; }
        public string estadoAprobacionParteTeorica { get; set; }
        public string horafinExamen { get; set; }
        public string  estadoadjunto1 { get; set; }
        public string estadoadjunto2 { get; set; }
        public string colaAdjuntos { get; set; }
        public string titularCatedra { get; set; }
        public string colaTitular { get; set; }
        public string acumTiempoTotalExamenAlumnosAprobados { get; set; }
        public string contAlumnosAprobados { get; set; }
        public List<Alumno> listaAlumnos { get; set; }

        public VectorEstado(
    int id,
    string eventoActual,
    string reloj,
    string rndfinPartePractica,
    string tiempofinPartePractica,
    string finfinPartePractica,
    string rndfinCorreccionPartePracticaAdjunto1,
    string tiempofinCorreccionPartePracticaAdjunto1,
    string finfinCorreccionPartePracticaAdjunto1,
    string rndfinCorreccionPartePracticaAdjunto2,
    string tiempoCorreccionPartePracticaAdjunto2,
    string finfinCorreccionPartePracticaAdjunto2,
    string rndAprobacionPartePractica,
    string estadoAprobacionPartePractica,
    string tiempofinCorreccionParteTeorica,
    string finfinCorreccionParteTeorica,
    string rndAprobacionParteTeorica,
    string estadoAprobacionParteTeorica,
    string horafinExamen,
    string estadoadjunto1,
    string estadoadjunto2,
    string colaAdjuntos,
    string titularCatedra,
    string colaTitular,
    string acumTiempoTotalExamenAlumnosAprobados,
    string contAlumnosAprobados,
    List<Alumno> listaAlumnos)
        {
            this.id = id;
            this.eventoActual = eventoActual;
            this.reloj = reloj;
            this.rndfinPartePractica = rndfinPartePractica;
            this.tiempofinPartePractica = tiempofinPartePractica;
            this.finfinPartePractica = finfinPartePractica;
            this.rndfinCorreccionPartePracticaAdjunto1 = rndfinCorreccionPartePracticaAdjunto1;
            this.tiempofinCorreccionPartePracticaAdjunto1 = tiempofinCorreccionPartePracticaAdjunto1;
            this.finfinCorreccionPartePracticaAdjunto1 = finfinCorreccionPartePracticaAdjunto1;
            this.rndfinCorreccionPartePracticaAdjunto2 = rndfinCorreccionPartePracticaAdjunto2;
            this.tiempoCorreccionPartePracticaAdjunto2 = tiempoCorreccionPartePracticaAdjunto2;
            this.finfinCorreccionPartePracticaAdjunto2 = finfinCorreccionPartePracticaAdjunto2;
            this.rndAprobacionPartePractica = rndAprobacionPartePractica;
            this.estadoAprobacionPartePractica = estadoAprobacionPartePractica;
            this.tiempofinCorreccionParteTeorica = tiempofinCorreccionParteTeorica;
            this.finfinCorreccionParteTeorica = finfinCorreccionParteTeorica;
            this.rndAprobacionParteTeorica = rndAprobacionParteTeorica;
            this.estadoAprobacionParteTeorica = estadoAprobacionParteTeorica;
            this.horafinExamen = horafinExamen;
            this.estadoadjunto1 = estadoadjunto1;
            this.estadoadjunto2 = estadoadjunto2;
            this.colaAdjuntos = colaAdjuntos;
            this.titularCatedra = titularCatedra;
            this.colaTitular = colaTitular;
            this.acumTiempoTotalExamenAlumnosAprobados = acumTiempoTotalExamenAlumnosAprobados;
            this.contAlumnosAprobados = contAlumnosAprobados;
            this.listaAlumnos = listaAlumnos;
        }

    }
}                                                                 
                                                                  