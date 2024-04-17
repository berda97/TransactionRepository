using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Serilog;
using System.Security.Cryptography;
using System.Text;
using TransactionRepository.Data;
using TransactionRepository.Interface;
using TransactionRepository.Model;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace TransactionRepository.Controllers
{
    [ApiController]
    [Route("api/transactions")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHashService _hashService;
        private readonly IConfiguration _configuration;
        private readonly ILogger<TransactionController> _logger;

        public TransactionController(ITransactionService transactionService, IHttpContextAccessor httpContextAccessor, IHashService hashService, IConfiguration configuration,ILogger<TransactionController> logger)
        {
            _transactionService = transactionService;
            _httpContextAccessor = httpContextAccessor;
            _hashService = hashService;
            _configuration = configuration;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] TransactionRequestDto request)
        {
            var requestJson = JsonConvert.SerializeObject(request);
            _logger.LogInformation("Received request: {RequestJson}", requestJson);
            string receivedHash = _httpContextAccessor.HttpContext.Request.Headers["hash"];
            string secretKey = _configuration["SettingsSecretKey:SecretKey"]; 
            string requestData = $"{request.ExternalTransactionId}{request.UserId}{request.Amount}{request.Currency}";

            if (!_hashService.IsValidHash(receivedHash, requestData, secretKey))
            {
                _logger.LogWarning("Invalid hash received for request: {@RequestData}", requestData);
                return BadRequest(new TransactionResponseDto { Message = "Invalid hash", Status = 1 });
            }
            var response = await _transactionService.ProcessTransactionAsync(request);
            _logger.LogInformation("Returned response: {@Response}", response);
            if (response.Status == 0)
            {
                return Ok(response);
            }

            return BadRequest(response);
            
           
        }
       
       
    }
}




