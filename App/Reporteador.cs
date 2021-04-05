using System;
using System.Linq;
using System.Collections.Generic;
using CoreEscuela.Entidades;

namespace CoreEscuela.App
{
    public class Reporteador
    {

        Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> _diccionario;
        
        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> diccionario)
        {
            if(diccionario == null)
            {
                throw new ArgumentNullException(nameof(diccionario));
            }
            _diccionario = diccionario;
        }

        public IEnumerable<Evaluación> GetListaEvaluaciones()
        {
            
            
            if (_diccionario.TryGetValue(LlaveDiccionario.Evaluaciones, 
                                            out IEnumerable<ObjetoEscuelaBase> lista))
            {
                return lista.Cast<Evaluación>();
            }else
            {
                return new List<Evaluación>();
                //Escribir en el log de auditoria.
            }
        }

        public IEnumerable<string> GetListAsignaturas()
        {
            return GetListAsignaturas(out var dummy);
        }
        
        public IEnumerable<string> GetListAsignaturas(out IEnumerable<Evaluación> listaEvaluaciones)
        {
            listaEvaluaciones = GetListaEvaluaciones();

            var resultado = (from ev in listaEvaluaciones 
                    //where ev.Nota >= 3.0f
                    select ev.Asignatura.Nombre).Distinct();

            return resultado;
        }

        public Dictionary<string, IEnumerable<Evaluación>> GetDiccionarioEvaluacionesXAsignatura()
        {
            var diccionarioRespuesta = new Dictionary<string, IEnumerable<Evaluación>>();

            var listaAsignaturas = GetListAsignaturas(out var listaEvaluaciones);

            foreach (var asignatura in listaAsignaturas)
            {
                var evalsAsig = from eval in listaEvaluaciones
                                where eval.Asignatura.Nombre == asignatura
                                select eval;
                diccionarioRespuesta.Add(asignatura, evalsAsig);
            }

            return diccionarioRespuesta;
        }
    }
}