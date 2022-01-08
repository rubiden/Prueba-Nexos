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
    public class AutorRepository : IAutorRepository
    {
        public readonly NexosDBContext _context;

        public AutorRepository(NexosDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> PostAutor(Autores autor)
        {
            using (_context)
            {
                _context.Autores.Add(autor);
                await _context.SaveChangesAsync();
            }

            return autor.Id;
        }

        public async Task<Autores> GetAutorById(int id)
        {
            return await _context.Autores.FindAsync(id);
        }
    }
}
