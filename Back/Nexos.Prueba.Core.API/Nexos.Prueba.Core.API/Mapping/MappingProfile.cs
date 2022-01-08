using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model = Nexos.Prueba.Domain.Core.Models;
using BM = Nexos.Prueba.Core.API.BindingModel;

namespace Nexos.Prueba.Core.API.Mapping
{
    /// <summary>
    /// Provide a profile for mapping
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Create mappings
        /// </summary>
        public MappingProfile()
        {
            CreateMap<BM.AutoresDTO, Model.Autores>().ReverseMap();
            CreateMap<BM.EditorialesDTO, Model.Editoriales>().ReverseMap();
            CreateMap<BM.LibrosDTO, Model.Libros>().ReverseMap();
            CreateMap<BM.FiltroLibroDTO, Model.FiltroLibro>().ReverseMap();
        }
    }
}
