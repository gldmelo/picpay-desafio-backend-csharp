using Microsoft.AspNetCore.Mvc;
using Moq;
using PicPay.Desafio.API.Usuarios;
using PicPay.Desafio.API.Usuarios.Models;
using PicPay.Desafio.Application.Usuarios;
using PicPay.Desafio.Domain.ValueObjects;
using PicPay.Desafio.Tests.Helpers;

namespace PicPay.Desafio.Tests.UsuarioTests;

public class TestSaldoController
{
    [Fact(DisplayName = "Retorna o saldo do usuário quando ele estiver Autenticado")]
    public void ShouldReturn_SaldoUsuario_When_UsuarioAutenticado()
    {
        // Arrange
        var mockUsuarioService = new Mock<IUsuarioService>();
        mockUsuarioService
            .Setup(service => service.ObterSaldo(1))
            .Returns(Result.Ok(new Dinheiro(100, "BRL")));

        var sutController = new SaldoController(mockUsuarioService.Object);
        sutController.ControllerContext = ControllerContextHelpers.CriarContextMock();

        // Act
        var resultActual = sutController.ObterSaldo();

        // Assert
        resultActual.Should().BeOfType<OkObjectResult>();

        var objectResult = (OkObjectResult)resultActual;
        objectResult.Value.Should().BeOfType<SaldoResponse>();

        var saldoUsuarioActual = (SaldoResponse)objectResult.Value!;
        saldoUsuarioActual.Saldo.Should().Be(100);
        saldoUsuarioActual.Moeda.Should().Be("BRL");
    }

    [Fact(DisplayName = "Retorna mensagem de erro quando há um erro na obtenção do Saldo")]
    public void ShouldReturn_ErroHttp500_When_OcorreErroNaConsulta()
    {
        // Arrange
        var mockUsuarioService = new Mock<IUsuarioService>();
        mockUsuarioService
            .Setup(service => service.ObterSaldo(1))
            .Returns(Result.Fail("Falha na leitura do banco de dados"));

        var sutController = new SaldoController(mockUsuarioService.Object);
        sutController.ControllerContext = ControllerContextHelpers.CriarContextMock();

        // Act
        var resultActual = sutController.ObterSaldo();

        // Assert
        resultActual.Should().BeOfType<ObjectResult>();

        var objectResult = (ObjectResult)resultActual;
        objectResult.StatusCode.Should().Be(500);
    }
}
