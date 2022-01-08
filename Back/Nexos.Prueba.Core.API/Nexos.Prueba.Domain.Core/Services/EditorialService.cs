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
    public class EditorialService : IEditorialService
    {
        private readonly IEditorialRepository _editorialRepository;

        public EditorialService(IEditorialRepository editorialRepository)
        {
            _editorialRepository = editorialRepository ?? throw new ArgumentNullException(nameof(editorialRepository));
        }

        public async Task<int> PostEditorial(Editoriales editorial)
        {
            editorial.MaximoLibros = editorial.MaximoLibros > 0 ? editorial.MaximoLibros : -1;

            return await _editorialRepository.PostEditorial(editorial);
        }

        public async Task<Editoriales> GetEditorialById(int id)
        {
            return await _editorialRepository.GetEditorialById(id);
        }

    }
}
