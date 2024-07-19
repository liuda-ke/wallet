using Microsoft.AspNetCore.Mvc;
using Wallet.Api.ModelTemplate;

namespace Wallet.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class RecordController : ControllerBase
{
    [HttpPost("save")]
    public async Task<ResponseModel> SaveWalletTask([FromBody] WalletTaskModel walletTaskModel)
    {
        return new ResponseModel()
        {
            code = 200,
            message = "oK"
        };
    }
}