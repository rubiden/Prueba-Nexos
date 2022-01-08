using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    /// Cantrolador para el manejo de autores
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class AutorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAutorService _autorService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="autorService"></param>
        public AutorController(IMapper mapper, IAutorService autorService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _autorService = autorService ?? throw new ArgumentNullException(nameof(autorService));
        }

        /// <summary>
        /// Crear autor
        /// </summary>
        /// <param name="autor"></param>
        /// /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response> 
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">InternalServerError. Error en el servidor.</response>
        /// <returns></returns>
        [HttpPost("PostAutor")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> PostAutor(BindingModel.AutoresDTO autor)
        {
            try
            {
                var autorM = _mapper.Map<Autores>(autor);

                var result = await _autorService.PostAutor(autorM);
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
