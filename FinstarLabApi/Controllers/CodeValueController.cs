using FinstarLab.Contract.Interfaces.Commands;
using FinstarLab.Contract.Interfaces.Queries;
using FinstarLab.Contract.Requests;
using FinstarLab.Contract.Responses;
using Microsoft.AspNetCore.Mvc;

namespace FinstarLab.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CodeValueController : ControllerBase
    {
        private readonly ILogger<CodeValueController> _logger;
        private readonly ICodeValueCommand _codeValueCommand;
        private readonly ICodeValueQuery _codeValueQuery;

        public CodeValueController(ILogger<CodeValueController> logger, ICodeValueCommand codeValueCommand, ICodeValueQuery codeValueQuery)
        {
            _logger = logger;
            _codeValueCommand = codeValueCommand;
            _codeValueQuery = codeValueQuery;
        }

        [HttpPost("codeValue/create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync(CodeValueCreateRequest codeValueRequest, CancellationToken cancellationToken)
        {
            await _codeValueCommand.Create(codeValueRequest, cancellationToken);
            return Ok();
        }

        [HttpPost("codeValue/get")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CodeValuesResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAsync(CodeValueGetRequest codeValueGetRequest, CancellationToken cancellationToken)
        {
            return Ok(await _codeValueQuery.GetAsync(codeValueGetRequest, cancellationToken));
        }
    }
}
