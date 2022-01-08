using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nexos.Prueba.Domain.Core.Models;
using Nexos.Prueba.Domain.Core.Services.InterfaceService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Nexos.Prueba.Core.API.Controllers
{
    /// <summary>
    /// Controlador para el manejo de editoriales
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class EditorialController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEditorialService _editorialService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="editorialService"></param>
        public EditorialController(IMapper mapper, IEditorialService editorialService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _editorialService = editorialService ?? throw new ArgumentNullException(nameof(editorialService));
        }

        /// <summary>
        /// Crear editorial
        /// </summary>
        /// <param name="editorial"></param>
        /// /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response> 
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">InternalServerError. Error en el servidor.</response>
        /// <returns></returns>
        [HttpPost("PostEditorial")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> PostEditorial(BindingModel.EditorialesDTO editorial)
        {
            try
            {
                var editorialM = _mapper.Map<Editoriales>(editorial);

                var result = await _editorialService.PostEditorial(editorialM);
                if (result == 0)
                    return BadRequest();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Code = 500, Message = "Algo salió mal. Por favor inténtelo de nuevo o contacte a su administrador.", DevMessage = e.Message });
            }
        }
    }
}
