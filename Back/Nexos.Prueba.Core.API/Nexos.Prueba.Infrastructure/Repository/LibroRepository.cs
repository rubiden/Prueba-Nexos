using Microsoft.EntityFrameworkCore;
using Nexos.Prueba.Domain.Core.Models;
using Nexos.Prueba.Domain.Core.Services.InterfaceRepository;
using Nexos.Prueba.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Prueba.Infrastructure.Repository
{
    public class LibroRepository : ILibroRepository
    {
        public readonly NexosDBContext _context;

        public LibroRepository(NexosDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> PostLibro(Libros libro)
        {
            using (_context)
            {
                _context.Libros.Add(libro);
                await _context.SaveChangesAsync();
            }

            return libro.Id;
        }

        public async Task<int> LibrosXeditorial(int idEditorial)
        {
            return await _context.Libros.Where(x => x.IdEditorial == idEditorial).CountAsync();
        }

        public async Task<IEnumerable<Libros>> GetLibrosXFiltro(FiltroLibro filtroLibro)
        {
            IEnumerable<Libros> libros;

            using (_context)
            {
                libros = await _context.Libros.Select(x => new Libros { 
                 Id = x.Id,
                 Titulo = x.Titulo,
                 Anio = x.Anio,
                 NumeroPaginas = x.NumeroPaginas,
                 IdAutor = x.IdAutor,
                 IdEditorial = x.IdEditorial,
                 Autor = new Autores
                 {
                     NombreCompleto = x.Autor.NombreCompleto
                 },
                 Editorial = new Editoriales
                 {
                     Nombre = x.Editorial.Nombre
                 }
                }).Where(x => (x.Anio.StartsWith(string.IsNullOrEmpty(filtroLibro.Anio) ? string.Empty : filtroLibro.Anio) || filtroLibro.Anio == null) 
                                                        && (x.Titulo.StartsWith(string.IsNullOrEmpty(filtroLibro.Titulo) ? string.Empty : filtroLibro.Titulo) || filtroLibro.Titulo == null)
                                                        && (x.Autor.NombreCompleto.StartsWith(string.IsNullOrEmpty(filtroLibro.Autor) ? string.Empty : filtroLibro.Autor) || filtroLibro.Autor == null)
                                                        ).ToListAsync();
            }

            return libros;
        }
    }
}
