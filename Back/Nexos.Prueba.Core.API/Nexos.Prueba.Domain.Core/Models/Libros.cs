using System;
using System.Collections.Generic;

namespace Nexos.Prueba.Domain.Core.Models
{
    public partial class Libros
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Anio { get; set; }
        public int NumeroPaginas { get; set; }
        public int IdEditorial { get; set; }
        public int IdAutor { get; set; }

        public virtual Autores Autor { get; set; }
        public virtual Editoriales Editorial { get; set; }
    }
}
