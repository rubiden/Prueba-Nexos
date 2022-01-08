using Nexos.Prueba.Domain.Core.Models;
using Nexos.Prueba.Domain.Core.Services.InterfaceRepository;
using Nexos.Prueba.Domain.Core.Services.InterfaceService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Prueba.Domain.Core.Services
{
    public class LibroService : ILibroService
    {
        private readonly ILibroRepository _libroRepository;

        public LibroService(ILibroRepository libroRepository)
        {
            _libroRepository = libroRepository ?? throw new ArgumentNullException(nameof(libroRepository));
        }

        public async Task<int> PostLibro(Libros libro)
        {
            return await _libroRepository.PostLibro(libro);
        }

        public async Task<int> LibrosXeditorial(int idEditorial)
        {
            return await _libroRepository.LibrosXeditorial(idEditorial);
        }

        public async Task<IEnumerable<Libros>> GetLibrosXFiltro(FiltroLibro filtroLibro)
        {
            return await _libroRepository.GetLibrosXFiltro(filtroLibro);
        }
    }
}
