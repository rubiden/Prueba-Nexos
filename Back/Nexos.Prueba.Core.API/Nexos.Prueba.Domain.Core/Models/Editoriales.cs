using System;
using System.Collections.Generic;

namespace Nexos.Prueba.Domain.Core.Models
{
    public partial class Editoriales
    {
        public Editoriales()
        {
            Libros = new HashSet<Libros>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int MaximoLibros { get; set; }

        public virtual ICollection<Libros> Libros { get; set; }
    }
}
