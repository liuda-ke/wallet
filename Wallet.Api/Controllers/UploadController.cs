using System.Collections.Concurrent;
using Microsoft.AspNetCore.Mvc;

namespace Wallet.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UploadController : ControllerBase
{
    [HttpPost("upload")]
    public async Task<IActionResult> UploadFile(IEnumerable<IFormFile>? files)
    {
        try
        {
            var pathDic = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
            // 创建不存在的目录
            Directory.CreateDirectory(pathDic);
            var fileNameDic = new ConcurrentBag<object>();
            foreach (var file in files)
            {
                var name = DateTime.Now.ToString("yyyyMMddHHmmsss") + "_" + DateTimeOffset.UtcNow.ToUnixTimeSeconds() + new Random().Next(0, 999);
                var fileName = name + Path.GetExtension(file.FileName);
                fileNameDic.Add(new
                {
                    key = file.FileName,
                    value = fileName
                });
                var path = Path.Combine(pathDic, fileName);
                await using var stream = new FileStream(path, FileMode.Create);
                await file.CopyToAsync(stream);
            }

            return Ok(new
            {
                message = "文件上传成功",
                filename = fileNameDic.FirstOrDefault()
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}