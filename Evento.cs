using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio70
{
    internal abstract class Evento
    {
        public string nombre { get; set; }
        protected float rnd { get; set; }
        protected float entreTiempo { get; set; }
        public float reloj { get; set; }
        protected Alumno alumno { get; set; }
        protected Profesor adjunto1 { get; set; }
        protected Profesor adjunto2 { get; set; }
        protected Profesor titularCatedra { get; set; }

        public Evento(string nombre, float reloj, Alumno alumno, Profesor adjunto1, Profesor adjunto2, Profesor titularCatedra)
        {
            this.nombre = nombre;
            this.reloj = reloj;
            this.alumno = alumno;
            this.adjunto1 = adjunto1;
            this.adjunto2 = adjunto2;
            this.titularCatedra = titularCatedra;
        }

        public virtual void GenerarEvento()
        {

        }


        public virtual void GenerarEvento(ref VectorEstado vectorEstado)
        {

        }

        public virtual void ResolverEvento(ref VectorEstado vectorEstado, List<Evento> colaEventos)
        {

        }



    }


    internal class FinPartePractica : Evento
    {

        public FinPartePractica(string nombre, float reloj, Alumno alumno, Profesor adjunto1, Profesor adjunto2, Profesor titularCatedra) : base(nombre, reloj, alumno, adjunto1, adjunto2, titularCatedra)
        {

        }

        public override void GenerarEvento()
        {
            rnd = (float)Math.Round(new Random().NextDouble(), 2);
            entreTiempo = -Simulacion.finPartePractica * (float)Math.Log(1 - rnd);
            reloj += entreTiempo;
        }

        public override void GenerarEvento(ref VectorEstado vectorEstado)
        {
            rnd = (float)Math.Round(new Random().NextDouble(), 2);
            entreTiempo = (float)Math.Round(-Simulacion.finPartePractica * (float)Math.Log(1 - rnd), 2);
            reloj += entreTiempo;
            vectorEstado.rndfinPartePractica = rnd.ToString();
            vectorEstado.tiempofinPartePractica = entreTiempo.ToString();
            vectorEstado.finfinPartePractica = reloj.ToString();

        }

        public override void ResolverEvento(ref VectorEstado vectorEstado, List<Evento> colaEventos)
        {
            // GENERAMOS EL PROXIMO FIN
            Evento eventoFinPartePractica = new FinPartePractica(nombre, reloj, alumno, adjunto1, adjunto2, titularCatedra);
            eventoFinPartePractica.GenerarEvento(ref vectorEstado);
            colaEventos.Add(eventoFinPartePractica);

            if (adjunto1.estado.Equals("Libre"))
            {
                adjunto1.estado = "Ocupado";
                alumno.estado = "En_Correccion_Adjunto1";

                vectorEstado.estadoadjunto1 = adjunto1.estado;
                int i = vectorEstado.listaAlumnos.IndexOf(alumno);
                vectorEstado.listaAlumnos[i].estado = alumno.estado;

                Evento eventoFinCorreccionAdjunto1 = new FinCorreccionAdjunto1("Fin_Correccion_Adj1", reloj, alumno, adjunto1, adjunto2, titularCatedra);
                eventoFinCorreccionAdjunto1.GenerarEvento(ref vectorEstado);
                colaEventos.Add(eventoFinCorreccionAdjunto1);



            }
            else if (adjunto2.estado.Equals("Libre"))
            {
                adjunto2.estado = "Ocupado";
                alumno.estado = "En_Correccion_Adjunto2";

                vectorEstado.estadoadjunto2 = adjunto2.estado;
                int i = vectorEstado.listaAlumnos.IndexOf(alumno);
                vectorEstado.listaAlumnos[i].estado = alumno.estado;

                Evento eventoFinCorreccionAdjunto2 = new FinCorreccionAdjunto2("Fin_Correccion_Adj2", reloj, alumno, adjunto1, adjunto2, titularCatedra);
                eventoFinCorreccionAdjunto2.GenerarEvento(ref vectorEstado);
                colaEventos.Add(eventoFinCorreccionAdjunto2);

            }
            else
            {
                adjunto1.cola.Alumnos.Enqueue(alumno);
                alumno.estado = "En_Cola_Adjuntos";
                int i = vectorEstado.listaAlumnos.IndexOf(alumno);
                vectorEstado.listaAlumnos[i].estado = alumno.estado;
                vectorEstado.colaAdjuntos = adjunto1.cola.Alumnos.Count().ToString();
            }

        }

    }

    internal class FinCorreccionAdjunto1 : Evento
    {

        public FinCorreccionAdjunto1(string nombre, float reloj, Alumno alumno, Profesor adjunto1, Profesor adjunto2, Profesor titularCatedra) : base(nombre, reloj, alumno, adjunto1, adjunto2, titularCatedra)
        {

        }
        public override void GenerarEvento(ref VectorEstado vectorEstado)
        {
            rnd = (float)Math.Round(new Random().NextDouble(), 2);
            entreTiempo = (float)Math.Round(Simulacion.finCorreccionPartePracticaA + (rnd * (Simulacion.finCorreccionPartePracticaB - Simulacion.finCorreccionPartePracticaA)), 2);
            reloj += entreTiempo;
            vectorEstado.rndfinCorreccionPartePracticaAdjunto1 = rnd.ToString();
            vectorEstado.tiempofinCorreccionPartePracticaAdjunto1 = entreTiempo.ToString();
            vectorEstado.finfinCorreccionPartePracticaAdjunto1 = reloj.ToString();
        }
        private bool generarAprobacion(float rnd)
        {
            if (rnd <= (Simulacion.porcAprobacionPract / 100))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override void ResolverEvento(ref VectorEstado vectorEstado, List<Evento> colaEventos)
        {
            // Resolvemos el alumno
            float rnd = (float)Math.Round(new Random().NextDouble(), 2);
            bool estadoExamenPractico = generarAprobacion(rnd);

            if (estadoExamenPractico == true)
            {
                // NOS FIJAMOS EN LA COLA DEL TITULAR 
                // SI ES MAYOR A 0 LO METEMOS A LA COLA
                // SI NO GENERAMOS EVENTO DE FIN EXAMEN TEORICO
            }
            else
            {
                alumno.estado = "Desaprobado";
            }

            // Actualizamos el vector con los datos del alumno
            int i = vectorEstado.listaAlumnos.IndexOf(alumno);
            vectorEstado.listaAlumnos[i].estado = alumno.estado;
            vectorEstado.rndAprobacionPartePractica = rnd.ToString();
            vectorEstado.estadoAprobacionPartePractica = estadoExamenPractico ? "Aprobado" : "Desaprobado";



            // Evaluamos la cola
            // Si no hay alumnos en la cola, el adjunto1 queda libre
            // Si hay alumnos en la cola, generamos evento de fin correccion adjunto1
            if (adjunto1.cola.Alumnos.Count() == 0)
            {
                adjunto1.estado = "Libre";
            }
            else
            {
                // Si hay alumnos en la cola, se atiende al primero
                Alumno alumnoAtendido = adjunto1.cola.Alumnos.Dequeue();
                alumnoAtendido.estado = "En_Correccion_Adjunto1";
                adjunto1.estado = "Ocupado";
                int j = vectorEstado.listaAlumnos.IndexOf(alumnoAtendido);
                vectorEstado.listaAlumnos[j].estado = alumnoAtendido.estado;
                Evento eventoFinCorreccionAdjunto1 = new FinCorreccionAdjunto1("Fin_Correccion_Adj1", reloj, alumnoAtendido, adjunto1, adjunto2, titularCatedra);
                eventoFinCorreccionAdjunto1.GenerarEvento(ref vectorEstado);
                colaEventos.Add(eventoFinCorreccionAdjunto1);
            }

            // Actualizamos el estado del vector con los datos del adjunto1
            vectorEstado.estadoadjunto1 = adjunto1.estado;

        }
    }


    internal class FinCorreccionAdjunto2 : Evento
    {
        public FinCorreccionAdjunto2(string nombre, float reloj, Alumno Alumno, Profesor adjunto1, Profesor adjunto2, Profesor titularCatedra) : base(nombre, reloj, Alumno, adjunto1, adjunto2, titularCatedra)
        {

        }

        
        public override void GenerarEvento(ref VectorEstado vectorEstado)
        {
            rnd = (float)Math.Round(new Random().NextDouble(), 2);
            entreTiempo = (float)Math.Round(Simulacion.finCorreccionPartePracticaA + (rnd * (Simulacion.finCorreccionPartePracticaB - Simulacion.finCorreccionPartePracticaA)), 2);
            reloj += entreTiempo;
            vectorEstado.rndfinCorreccionPartePracticaAdjunto2 = rnd.ToString();
            vectorEstado.tiempofinCorreccionPartePracticaAdjunto2 = entreTiempo.ToString();
            vectorEstado.finfinCorreccionPartePracticaAdjunto2 = reloj.ToString();
        }

        private bool generarAprobacion(float rnd)
        {
            if (rnd <= (Simulacion.porcAprobacionPract / 100))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void ResolverEvento(ref VectorEstado vectorEstado, List<Evento> colaEventos)
        {
            // Resolvemos el alumno
            float rnd = (float)Math.Round(new Random().NextDouble(), 2);
            bool estadoExamenPractico = generarAprobacion(rnd);

            if (estadoExamenPractico == true)
            {
                // NOS FIJAMOS EN LA COLA DEL TITULAR 
                // SI ES MAYOR A 0 LO METEMOS A LA COLA
                // SI NO GENERAMOS EVENTO DE FIN EXAMEN TEORICO
            }
            else
            {
                alumno.estado = "Desaprobado";
            }

            // Actualizamos el vector con los datos del alumno
            int i = vectorEstado.listaAlumnos.IndexOf(alumno);
            vectorEstado.listaAlumnos[i].estado = alumno.estado;
            vectorEstado.rndAprobacionPartePractica = rnd.ToString();
            vectorEstado.estadoAprobacionPartePractica = estadoExamenPractico ? "Aprobado" : "Desaprobado";



            // Evaluamos la cola
            // Si no hay alumnos en la cola, el adjunto1 queda libre
            // Si hay alumnos en la cola, generamos evento de fin correccion adjunto1
            if (adjunto2.cola.Alumnos.Count() == 0)
            {
                adjunto2.estado = "Libre";
            }
            else
            {
                // Si hay alumnos en la cola, se atiende al primero
                Alumno alumnoAtendido = adjunto2.cola.Alumnos.Dequeue();
                alumnoAtendido.estado = "En_Correccion_Adjunto1";
                adjunto2.estado = "Ocupado";
                int j = vectorEstado.listaAlumnos.IndexOf(alumnoAtendido);
                vectorEstado.listaAlumnos[j].estado = alumnoAtendido.estado;
                Evento eventoFinCorreccionAdjunto2 = new FinCorreccionAdjunto2("Fin_Correccion_Adj2", reloj, alumnoAtendido, adjunto1, adjunto2, titularCatedra);
                eventoFinCorreccionAdjunto2.GenerarEvento(ref vectorEstado);
                colaEventos.Add(eventoFinCorreccionAdjunto2);
            }

            // Actualizamos el estado del vector con los datos del adjunto1
            vectorEstado.estadoadjunto2 = adjunto2.estado;

        }

    }
    /**
internal class FinCorreccionTeorico : Evento
{
    public FinCorreccionTeorico(float reloj, Alumno Alumno, Profesor profesor) : base(reloj, Alumno, profesor)
    {

    }

    public override void ResolverEvento(ref VectorEstado vectorEstado)
    {

    }

}
internal class FinExamen : Evento
{
    public FinExamen(float reloj, Alumno Alumno, Profesor profesor) : base(reloj, Alumno, profesor)
    {

    }

    public override void ResolverEvento(ref VectorEstado vectorEstado)
    {

    }

}
**/

}
