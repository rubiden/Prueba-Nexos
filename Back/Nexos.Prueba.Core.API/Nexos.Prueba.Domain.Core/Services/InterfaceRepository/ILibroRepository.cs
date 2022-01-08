using Nexos.Prueba.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Prueba.Domain.Core.Services.InterfaceRepository
{
    public interface ILibroRepository
    {
        Task<int> PostLibro(Libros libro);
        Task<int> LibrosXeditorial(int idEditorial);
        Task<IEnumerable<Libros>> GetLibrosXFiltro(FiltroLibro filtroLibro);
    }
}
