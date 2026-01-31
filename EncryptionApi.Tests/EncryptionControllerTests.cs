using Xunit;
using Microsoft.AspNetCore.Mvc;
using EncryptionAPI.Controllers;

namespace EncryptionApi.Tests;

public class EncryptionControllerTests
{
    private readonly EncryptionController _controller;

    public EncryptionControllerTests()
    {
        _controller = new EncryptionController();
    }

    [Fact]
    public void Encrypt_WithValidInput_ReturnsEncryptedText()
    {
        // Arrange
        var request = new EncryptionRequest("Hello", 3);

        // Act
        var result = _controller.Encrypt(request);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var response = Assert.IsType<EncryptionResponse>(okResult.Value);
        Assert.Equal("Khoor", response.Result);
    }

    [Fact]
    public void Decrypt_WithValidInput_ReturnsDecryptedText()
    {
        // Arrange
        var request = new EncryptionRequest("Khoor", 3);

        // Act
        var result = _controller.Decrypt(request);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var response = Assert.IsType<EncryptionResponse>(okResult.Value);
        Assert.Equal("Hello", response.Result);
    }

    [Fact]
    public void Encrypt_WithEmptyText_ReturnsBadRequest()
    {
        // Arrange
        var request = new EncryptionRequest("", 3);

        // Act
        var result = _controller.Encrypt(request);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result.Result);
    }

    [Fact]
    public void Encrypt_PreservesNonLetters()
    {
        // Arrange
        var request = new EncryptionRequest("Hello World!", 3);

        // Act
        var result = _controller.Encrypt(request);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var response = Assert.IsType<EncryptionResponse>(okResult.Value);
        Assert.Equal("Khoor Zruog!", response.Result);
    }
}