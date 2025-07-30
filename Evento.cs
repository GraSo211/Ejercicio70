using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio70
{
    internal abstract class Evento
    {
        protected string nombre { get; set; }
        protected float rnd { get; set; }
        protected float entreTiempo { get; set; }
        public float reloj { get; set; }
        protected Alumno Alumno { get; set; }
        protected Profesor profesor{ get; set; }

        public Evento(float reloj, Alumno Alumno, Profesor profesor )
        {
            this.reloj = reloj;
            this.Alumno = Alumno;
            this.profesor = profesor;
        }

        public virtual void GenerarEvento()
        {
            
        }
        public virtual void GenerarEvento(float numeroA)
        {

        }
        public virtual void GenerarEvento(ref VectorEstado vectorEstado, float numeroA)
        {

        }

        public virtual void ResolverEvento(ref VectorEstado vectorEstado)
        {
            
        }

        public virtual void ResolverEvento(ref VectorEstado vectorEstado, float numeroA)
        {
            
        }

    }


    internal class FinPartePractica: Evento
    {
        public FinPartePractica(float reloj, Alumno Alumno, Profesor profesor): base(reloj, Alumno, profesor)
        {     
        }

        public override void GenerarEvento(float media)
        {
            rnd =(float) Math.Round( new Random().NextDouble(),2);
            entreTiempo = -media * (float)Math.Log(1-rnd);
            reloj += entreTiempo;

        }

        public override void GenerarEvento(ref VectorEstado vectorEstado, float media)
        {
            rnd = (float)Math.Round(new Random().NextDouble(), 2);
            entreTiempo = -media * (float)Math.Log(1 - rnd);
            reloj += entreTiempo;

        }

        public override void ResolverEvento(ref VectorEstado vectorEstado)
        {
            

        }

    }

    internal class FinCorreccionAdjunto1 : Evento
    {
        public FinCorreccionAdjunto1(float reloj, Alumno Alumno, Profesor profesor) : base(reloj, Alumno, profesor)
        {

        }

        public override void ResolverEvento(ref VectorEstado vectorEstado)
        {

        }

    }
    internal class FinCorreccionAdjunto2 : Evento
    {
        public FinCorreccionAdjunto2(float reloj, Alumno Alumno, Profesor profesor) : base(reloj, Alumno, profesor)
        {

        }

        public override void ResolverEvento(ref VectorEstado vectorEstado)
        {

        }

    }
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

}
