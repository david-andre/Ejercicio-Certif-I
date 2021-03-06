//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BEUEjercicio
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Alumno
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Alumno()
        {
            this.Matriculas = new HashSet<Matricula>();
        }
    
        [ScaffoldColumn(false)]
        public int idalumno { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Los nombres es requeridos"), MaxLength(55)]
        [Display(Name = "Nombres")]
        public string nombre { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Los apellidos es requeridos"), MaxLength(55)]
        [Display(Name = "Apellidos")]
        public string apellidos { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Los cédula es requerida"), MaxLength(15)]
        [Display(Name = "Cédula")]
        public string cedula { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd'/'MM'/'yyyy}")]
        public Nullable<System.DateTime> fecha_nacimiento { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Lugar de nacimiento")]
        public string lugar_nacimiento { get; set; }

        [Display(Name = "Sexo")]
        public string sexo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
