using System;
using System.Collections.Generic;

namespace Nexos.Prueba.Domain.Core.Models
{
    public partial class Autores
    {
        public Autores()
        {
            Libros = new HashSet<Libros>();
        }

        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string CiudadNacimiento { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Libros> Libros { get; set; }
    }
}
