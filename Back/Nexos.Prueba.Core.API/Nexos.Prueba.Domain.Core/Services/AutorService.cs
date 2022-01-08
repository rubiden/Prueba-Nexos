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
    public class AutorService : IAutorService
    {
        private readonly IAutorRepository _autorRepository;

        public AutorService(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository ?? throw new ArgumentNullException(nameof(autorRepository));
        }

        public async Task<int> PostAutor(Autores autor)
        {
            return await _autorRepository.PostAutor(autor);
        }

        public async Task<Autores> GetAutorById(int id)
        {
            return await _autorRepository.GetAutorById(id);
        }
    }
}
