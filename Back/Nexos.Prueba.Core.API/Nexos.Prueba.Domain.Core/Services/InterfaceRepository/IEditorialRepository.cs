using Nexos.Prueba.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Prueba.Domain.Core.Services.InterfaceRepository
{
    public interface IEditorialRepository
    {
        Task<int> PostEditorial(Editoriales editorial);
        Task<Editoriales> GetEditorialById(int id);
    }
}
