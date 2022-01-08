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
    /// Cantrolador para el manejo de libros
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class LibroController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILibroService _libroService;
        private readonly IAutorService _autorService;
        private readonly IEditorialService _editorialService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="libroService"></param>
        /// <param name="autorService"></param>
        /// <param name="editorialService"></param>
        public LibroController(IMapper mapper, ILibroService libroService, IAutorService autorService, IEditorialService editorialService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _libroService = libroService ?? throw new ArgumentNullException(nameof(libroService));
            _autorService = autorService ?? throw new ArgumentNullException(nameof(autorService));
            _editorialService = editorialService ?? throw new ArgumentNullException(nameof(editorialService));
        }

        /// <summary>
        /// Crear libro
        /// </summary>
        /// <param name="libro"></param>
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
        public async Task<IActionResult> PostAutor(BindingModel.LibrosDTO libro)
        {
            try
            {
                var editorial = await _editorialService.GetEditorialById(libro.IdEditorial);
                if (editorial == null)
                    return NotFound("La editorial no está registrada");

                var autor = await _autorService.GetAutorById(libro.IdAutor);
                if (autor == null)
                    return NotFound("El autor no está registrado");

                var numLib = _libroService.LibrosXeditorial(libro.IdEditorial);
                if (editorial.MaximoLibros != -1 && numLib.Result == editorial.MaximoLibros)
                    return BadRequest("No es posible registrar el libro, se alcanzó el máximo permitido.");

                var libroM = _mapper.Map<Libros>(libro);

                var result = await _libroService.PostLibro(libroM);
                if (result == 0)
                    return BadRequest();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Code = 500, Message = "Algo salió mal. Por favor inténtelo de nuevo o contacte a su administrador.", DevMessage = e.Message });
            }
        }

        /// <summary>
        /// Obtener libros por filtro
        /// </summary>
        /// <param name="filtro"></param>
        /// /// <response code="200">OK. Devuelve el objeto solicitado.</response> 
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response> 
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">InternalServerError. Error en el servidor.</response>
        /// <returns></returns>
        [HttpGet("GetLibrosXFiltro")]
        [ProducesResponseType(typeof(BindingModel.LibrosDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetLibrosXFiltro([FromQuery] BindingModel.FiltroLibroDTO filtro)
        {
            try
            {
                var filtroM = _mapper.Map<FiltroLibro>(filtro);

                var result = await _libroService.GetLibrosXFiltro(filtroM);
                if (!result.Any())
                    return NotFound();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Code = 500, Message = "Algo salió mal. Por favor inténtelo de nuevo o contacte a su administrador.", DevMessage = e.Message });
            }
        }
    }
}
