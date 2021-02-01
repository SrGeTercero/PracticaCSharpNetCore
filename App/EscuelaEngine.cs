using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;

namespace CoreEscuela
{ 
    public sealed class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {
            
        }

        public void Inicializar()
        {
            Escuela = new Escuela("San Mateo Academy", 2012, TiposEscuela.Primaria,
                //opcionales, no asignalos o en un orden distionto al que fueron colocados
                ciudad: "Villa Nueva", pais: "Guatemala"
            );
            
            CargarCursos(); //aca dentro de la funcio se crean los cursos, luego a cada curso los alumnos...
            CargarAsignaturas(); //luego crea asignaturas y las agrega a cada curso
            CargarEvaluaciones();
        }

        public Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> GetDiccionarioDeObjetos()
        {
           
            var diccionario = new Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>>();

            diccionario.Add(LlaveDiccionario.Escuela,new[] {Escuela});
            diccionario.Add(LlaveDiccionario.Curso,Escuela.Cursos.Cast<ObjetoEscuelaBase>());

            return diccionario;
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuela(
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool treaAsignaturas = true,
            bool traeCursos = true)
        {
            return GetObjetoEscuela(out int dummy, out dummy, out dummy, out dummy);
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuela(
            out int conteoEvaluaciones,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool treaAsignaturas = true,
            bool traeCursos = true)
        {
            return GetObjetoEscuela(out conteoEvaluaciones, out int dummy, out dummy, out dummy);
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuela(
            out int conteoEvaluaciones,
            out int conteoAlumnos,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool treaAsignaturas = true,
            bool traeCursos = true)
        {
            return GetObjetoEscuela(out conteoEvaluaciones, out conteoAlumnos, out int dummy, out dummy);
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuela(
            out int conteoEvaluaciones,
            out int conteoAlumnos,
            out int conteoAsignaturas,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool treaAsignaturas = true,
            bool traeCursos = true)
        {
            return GetObjetoEscuela(out conteoEvaluaciones, out conteoAlumnos, out conteoAsignaturas, out int dummy);
        }


        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuela(
            out int conteoEvaluaciones,
            out int conteoAlumnos,
            out int conteoAsignaturas,
            out int conteoCursos,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool treaAsignaturas = true,
            bool traeCursos = true)
        {
            conteoAlumnos = conteoAsignaturas = conteoEvaluaciones = 0;
            
            var listaObj = new List<ObjetoEscuelaBase>();
            listaObj.Add(Escuela);

            if(traeCursos)
                listaObj.AddRange(Escuela.Cursos);
            
            conteoCursos = Escuela.Cursos.Count;
            foreach (var curso in Escuela.Cursos)
            {
                conteoAsignaturas += curso.Asignaturas.Count;
                conteoAlumnos += curso.Alumnos.Count;
                
                if(treaAsignaturas)
                    listaObj.AddRange(curso.Asignaturas);

                if (traeAlumnos)
                    listaObj.AddRange(curso.Alumnos);
                
                if (traeEvaluaciones)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        listaObj.AddRange(alumno.Evaluaciones);
                        conteoEvaluaciones += alumno.Evaluaciones.Count;
                    }
                }
            }

            return listaObj.AsReadOnly();
        }

        #region Metodos de carga
        private void CargarEvaluaciones()
        {
            Random rnd = new Random();
            foreach (var curso in Escuela.Cursos)
            {
                foreach (var alumno in curso.Alumnos)
                {
                    foreach (var asignatura in curso.Asignaturas)
                    {
                        for(int i = 0; i < 5; i++){
                            
                            var evaluacion = new Evaluación
                            {
                                Nombre = $"{asignatura.Nombre} Ev#{i+1}", 
                                Alumno = alumno, 
                                Asignatura = asignatura, 
                                Nota = (float) rnd.NextDouble() * 5
                            };    
                            
                            alumno.Evaluaciones.Add(evaluacion);
                            
                            //Console.WriteLine($"Id evaluación: {evaluacion.UniqueId}, Nombre evaluación: {evaluacion.Nombre}, Alumno: {evaluacion.Alumno.Nombre}, Asignatura: {evaluacion.Asignatura.Nombre}, Nota: {evaluacion.Nota}");
                        }                        
                    }   
                }
            }
        }

        private void CargarAsignaturas()
        {
            foreach(var curso in Escuela.Cursos)
            {
                List<Asignatura> listaAsignaturas = new List<Asignatura>()
                {
                    new Asignatura{Nombre = "Matemáticas"},
                    new Asignatura{Nombre = "Educación Física"},
                    new Asignatura{Nombre = "Castellano"},
                    new Asignatura{Nombre = "Ciencias Naturales"}
                };
                curso.Asignaturas = listaAsignaturas;
            }
        }

        private List<Alumno> GenerarAlumnosAlAzar(int cantidad)
        {
            string[] nombre1 = {"German","Luis","Devora","Irma","Alison","Juan","Pedro"};
            string[] apellido1 = {"Sandoval","Orantes","Rodriguez","Perez","Alvarez","Alvizuez","Cuellar"};
            string[] nombre2 = {"Arturo","Jose","Yolanda","David","Diana","Nicole","Jonas"};

            //como hacer la convinatoria de los elmentos de estos arreglos.
            //usaremos linq, sql embebido en c#
            var listaDeAlumnos = from n1 in nombre1
                                    from n2 in nombre2
                                    from a1 in apellido1
                                    select new Alumno{Nombre = $"{n1} {n2} {a1}"};
            
            return listaDeAlumnos.OrderBy((al) => al.UniqueId).Take(cantidad).ToList();
        }

        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>(){
                new Curso(){Nombre = "101", Jornada = TiposJornada.Mañana},
                new Curso(){Nombre = "201", Jornada = TiposJornada.Mañana},
                new Curso(){Nombre = "301", Jornada = TiposJornada.Mañana},
                new Curso(){Nombre = "401", Jornada = TiposJornada.Tarde},
                new Curso(){Nombre = "501", Jornada = TiposJornada.Tarde},
            };

            Random rnd = new Random();
            foreach (var curso in Escuela.Cursos)
            {
                int cantidadRandom = rnd.Next(5,20);
                curso.Alumnos = GenerarAlumnosAlAzar(cantidadRandom);
            }
        }

        #endregion
    }
}