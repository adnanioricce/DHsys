using Core.Entities;
using Core.Validations;
using Moq;
using System;
using Xunit;

namespace Core.Tests.Validations
{
    public class ContaValidatorTests
    {        
        private ContaValidator CreateContaValidator()
        {
            return new ContaValidator();
        }

        [Fact]
        public void IsValid_ValidState_ReturnValidResult()
        {
            // Arrange
            var contaValidator = this.CreateContaValidator();
            Conta conta = new Conta {
                DataDeVencimento = DateTime.UtcNow.AddDays(30).ToShortDateString(),
                NomeEmpresa = "empresa",
                Valor = 123.99m,
                EstaPago = false
            };

            // Act
            var result = contaValidator.IsValid(
                conta);

            // Assert
            Assert.True(result);            
        }
        [Theory]
        [InlineData("01")]
        [InlineData("01/00/0000")]
        [InlineData("123456789")]
        [InlineData("2000/00/00")]
        public void IsValid_InvalidDataDeVencimentoState_ReturnError(string dataDeVencimento)
        {
            var contaValidator = this.CreateContaValidator();
            Conta conta = new Conta
            {
                DataDeVencimento = dataDeVencimento,
                NomeEmpresa = "empresa",
                Valor = 123.99m,
                EstaPago = false
            };

            // Act
            var result = contaValidator.IsValid(conta);

            // Assert
            Assert.False(result);
        }
        [Theory]
        [InlineData("")]        
        public void IsValid_InvalidNomeEmpresaState_ReturnError(string nomeEmpresa)
        {
            var contaValidator = this.CreateContaValidator();
            Conta conta = new Conta
            {
                DataDeVencimento = DateTime.UtcNow.AddDays(30).ToShortDateString(),
                NomeEmpresa = nomeEmpresa,
                Valor = 123.99m,
                EstaPago = false
            };

            // Act
            var result = contaValidator.IsValid(conta);

            // Assert
            Assert.False(result);
        }
        [Theory]
        [InlineData(-10)]
        [InlineData(0)]
        public void IsValid_InvalidValorState_ReturnError(decimal valor)
        {
            var contaValidator = this.CreateContaValidator();
            Conta conta = new Conta
            {
                DataDeVencimento = DateTime.UtcNow.AddDays(30).ToShortDateString(),
                NomeEmpresa = "empresa",
                Valor = valor,
                EstaPago = false
            };

            // Act
            var result = contaValidator.IsValid(conta);

            // Assert
            Assert.False(result);
        }
    }
}
