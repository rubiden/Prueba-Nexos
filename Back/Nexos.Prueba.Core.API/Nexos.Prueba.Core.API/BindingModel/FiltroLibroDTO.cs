using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nexos.Prueba.Core.API.BindingModel
{
    /// <summary>
    /// Clase para la realización de busquedas de libros
    /// </summary>
    public class FiltroLibroDTO
    {
        /// <summary>
        /// Autor del libro
        /// </summary>
        public string Autor { get; set; }
        /// <summary>
        /// Título del libro
        /// </summary>
        public string Titulo { get; set; }
        /// <summary>
        /// Año de publicación del libro
        /// </summary>
        public string Anio { get; set; }
    }
}
