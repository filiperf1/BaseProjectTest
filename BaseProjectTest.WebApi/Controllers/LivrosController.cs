using BaseProjectTest.Models.Entities;
using BaseProjectTest.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace BaseProjectTest.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : Controller
    {
        private readonly ILivrosService _livrosService;

        public LivrosController(ILivrosService LivrosService)
        {
            _livrosService = LivrosService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Listagem de Livros", Description = "Busca os dados dos livros em banco")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IList<Livros>))]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IList<Livros>>> GetLivrosAsync()
        {
            var result = await _livrosService.ListLivrosAsync();
            return Ok(result);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastro de Livros", Description = "Endpoint para cadastro de livro")]
        [SwaggerResponse(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> PostLivrosAsync(Livros request)
        {
            await _livrosService.AddLivrosAsync(request);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update de Livros", Description = "Endpoint para update de livro")]
        [SwaggerResponse(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> PutLivrosAsync(Livros request)
        {
            var result = await _livrosService.UpdateLivro(request);
            return Ok();
        }

        [HttpDelete]
        [SwaggerOperation(Summary = "Remocao de Livros", Description = "Endpoint para remocao de livro")]
        [SwaggerResponse(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteLivrosAsync([FromQuery(Name = "LivroId")]int requestId)
        {
            await _livrosService.DeleteLivrosAsync(requestId);
            return Ok();
        }

    }
}
