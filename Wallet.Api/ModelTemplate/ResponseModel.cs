namespace Wallet.Api.ModelTemplate;

public class ResponseModel
{
    public int code { get; set; }
    
    public string message { get; set; }
    
    public object data { get; set; }
}