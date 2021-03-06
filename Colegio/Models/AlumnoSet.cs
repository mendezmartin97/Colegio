//------------------------------------------------------------------------------
// <auto-generated>
//     Este c�digo se gener� a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicaci�n.
//     Los cambios manuales en este archivo se sobrescribir�n si se regenera el c�digo.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Colegio.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial class AlumnoSet
    {
        private ColegioEntities db = new ColegioEntities();
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AlumnoSet()
        {
            this.ProfesorSets = new HashSet<ProfesorSet>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Legajo { get; set; }
        public string Mail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProfesorSet> ProfesorSets { get; set; }

        public AlumnoSet(int id, string nombre, string legajo, string mail)
        {
            Id = id;
            Nombre = nombre;
            Legajo = legajo;
            Mail = mail;

        }
        public static AlumnoSet BuscarPorId(int idBuscado)
        {

            AlumnoSet alu = null;
            ColegioEntities d = new ColegioEntities();
            var resultados = (from x in d.AlumnoSets
                              where x.Id == idBuscado
                              select x);

            if (resultados.Count() > 0)
            {
                var e = resultados.First();
                alu = new AlumnoSet(e.Id, e.Nombre, e.Legajo, e.Mail);
            }

            return alu;
        }

        /*public AlumnoSet Obtener(int id)
         {
             var alumno = new AlumnoSet();
             try
             {
                 using (var context = new ColegioEntities())
                 {
                     var resultados = (from x in context
                                       where x.id == idBuscado
                                       select x);

                 }
             }
             catch (Exception e)
             {
                 throw new Exception(e.Message);
             }

             return alumno;
         }*/
        /* public static List<AlumnoSet> Buscar(int id)
         {
             List<AlumnoSet> encontrados = new List<AlumnoSet>();


             var resultados = (from x in db.AlumnoSets
                               where id == x.id
                               select x
                               );
             foreach (var e in resultados)
             {

                 encontrados.Add(new AlumnoSet());
             }

             return encontrados;
         }*/

    }
}
