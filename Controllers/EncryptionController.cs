using Microsoft.AspNetCore.Mvc;

namespace EncryptionAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EncryptionController : ControllerBase
{
    [HttpPost("encrypt")]
    public ActionResult<EncryptionResponse> Encrypt([FromBody] EncryptionRequest request)
    {
        if (string.IsNullOrEmpty(request.Text))
            return BadRequest("Text cannot be empty");

        var encrypted = CaesarCipher(request.Text, request.Shift);
        return Ok(new EncryptionResponse(encrypted));
    }

    [HttpPost("decrypt")]
    public ActionResult<EncryptionResponse> Decrypt([FromBody] EncryptionRequest request)
    {
        if (string.IsNullOrEmpty(request.Text))
            return BadRequest("Text cannot be empty");

        var decrypted = CaesarCipher(request.Text, -request.Shift);
        return Ok(new EncryptionResponse(decrypted));
    }

    private string CaesarCipher(string text, int shift)
    {
        var result = "";
        foreach (char c in text)
        {
            if (char.IsLetter(c))
            {
                char offset = char.IsUpper(c) ? 'A' : 'a';
                result += (char)((((c + shift) - offset + 26) % 26) + offset);
            }
            else
            {
                result += c;
            }
        }
        return result;
    }
}

public record EncryptionRequest(string Text, int Shift = 3);
public record EncryptionResponse(string Result);