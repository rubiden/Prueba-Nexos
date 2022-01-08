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
    public class EditorialRepository : IEditorialRepository
    {
        public readonly NexosDBContext _context;

        public EditorialRepository(NexosDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> PostEditorial(Editoriales editorial)
        {
            using (_context)
            {
                _context.Editoriales.Add(editorial);
                await _context.SaveChangesAsync();
            }

            return editorial.Id;
        }

        public async Task<Editoriales> GetEditorialById(int id)
        {
            return await _context.Editoriales.FindAsync(id);
        }
    }
}
