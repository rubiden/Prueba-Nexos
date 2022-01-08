using Nexos.Prueba.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Prueba.Domain.Core.Services.InterfaceRepository
{
    public interface IAutorRepository
    {
        Task<int> PostAutor(Autores autor);
        Task<Autores> GetAutorById(int id);
    }
}
