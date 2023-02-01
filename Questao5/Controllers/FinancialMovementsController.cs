using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Domain.Exceptions;

namespace Questao5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinancialMovementsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FinancialMovementsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Registra uma movimentação financeira de um conta bancária.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     POST /api/FinancialMovements
        ///     {
        ///         "requestId": "2B33C02C-2D8D-46E0-80A5-A81E67E0130D",
        ///         "bankAccountId": "FA99D033-7067-ED11-96C6-7C5DFA4A16C9",
        ///         "movementType": "C",
        ///         "value": 10
        ///     }
        ///  
        /// </remarks>
        /// <param name="command"></param>
        /// <returns>Retorna o Identificador da movimentação financeira</returns>
        /// <response code="200">Movimentação financeira realizada</response>
        /// <response code="400">Falha ao realizar movimentação financeira</response>  
        /// <response code="404">Erro ao buscar a conta</response>  
        /// <response code="409">Solicitação já processada</response>  
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<CreateFinancialMovementResponse>> CreateFinancialMovement([FromBody] CreateFinancialMovementCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (ConflictException ex)
            {
                return new ContentResult() { Content = $"{ex.ExceptionType}: {ex.Message}", StatusCode = (int)ex.StatusCodes };
            }
            catch (InvalidAccountException ex)
            {
                return new ContentResult() { Content = $"{ex.ExceptionType}: {ex.Message}", StatusCode = (int)ex.StatusCodes };
            }
            catch (InactiveAccountException ex)
            {
                return new ContentResult() { Content = $"{ex.ExceptionType}: {ex.Message}", StatusCode = (int)ex.StatusCodes };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
