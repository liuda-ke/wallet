namespace Wallet.Api.ModelTemplate;

public class WalletTaskModel
{
    /// <summary>
    /// 金额
    /// </summary>
    public string Amount { get; set; }

    /// <summary>
    /// 文件
    /// </summary>
    public List<string> Files { get; set; }

    /// <summary>
    /// 事件
    /// </summary>
    public string Things { get; set; }

    /// <summary>
    /// 事件
    /// </summary>
    public string Time { get; set; }
}