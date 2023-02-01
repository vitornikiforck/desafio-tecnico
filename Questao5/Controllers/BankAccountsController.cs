using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Queries.Requests;
using Questao5.Application.Queries.Responses;
using Questao5.Domain.Exceptions;

namespace Questao5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankAccountsController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public BankAccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Busca os dados de uma determinada conta bancária pelo seu identificador.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        /// 
        ///     GET /api/BankAccounts/FA99D033-7067-ED11-96C6-7C5DFA4A16C9
        ///     
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Retorna os dados de uma determinada conta bancária</returns>
        /// <response code="200">Conta bancária encontrada</response>
        /// <response code="400">Falha ao buscar conta bancária</response>  
        /// <response code="404">Erro ao buscar a conta bancária</response>  
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BankAccountGetBalanceResponse>> Get(string id)
        {
            try
            {
                var result = await _mediator.Send(new GetBankAccountBalanceByIdQuery(id));
                return Ok(result);
            }

            catch (InvalidAccountException ex)
            {
                return new ContentResult() { Content = $"{ex.ExceptionType}: {ex.Message}", StatusCode = (int)ex.StatusCodes };
            }
            catch (InactiveAccountException ex)
            {
                return new ContentResult() { Content = $"{ex.ExceptionType}: {ex.Message}", StatusCode = (int)ex.StatusCodes };
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }
    }
}