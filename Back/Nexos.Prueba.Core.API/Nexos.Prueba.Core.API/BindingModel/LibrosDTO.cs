using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nexos.Prueba.Core.API.BindingModel
{
    /// <summary>
    /// Clase para el manejo de los libros
    /// </summary>
    public class LibrosDTO
    {
        /// <summary>
        /// Id del libro
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Titulo del libro
        /// </summary>
        [Required(ErrorMessage = "El titulo del libro es reuqerido")]
        public string Titulo { get; set; }
        /// <summary>
        /// Año del libro
        /// </summary>
        [Required(ErrorMessage = "El año del libro es reuqerido")]
        [ValidateYear(ErrorMessage ="El año ingresado no es válido")]
        public string Anio { get; set; }
        /// <summary>
        /// Número de paginas del libro
        /// </summary>
        public int NumeroPaginas { get; set; }
        /// <summary>
        /// Id del la editorial
        /// </summary>
        public int IdEditorial { get; set; }
        /// <summary>
        /// Id del autor
        /// </summary>
        public int IdAutor { get; set; }
        /// <summary>
        /// Autor del libro
        /// </summary>
        public virtual AutoresDTO Autor { get; set; }
        /// <summary>
        /// Editorial del libro
        /// </summary>
        public virtual EditorialesDTO Editorial { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ValidateYearAttribute : ValidationAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            string year = (string)value;
            if (!DateTime.TryParseExact(year, "yyyy", null, System.Globalization.DateTimeStyles.None, out _))
            {
                return false;
            }
            return true;
        }
    }
}
