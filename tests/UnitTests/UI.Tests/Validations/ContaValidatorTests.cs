using Moq;
using System;
using Xunit;
using Core.Validations;
using Core.Entities;

namespace UI.Tests.Validations
{
    public class ContaValidatorTests
    {        
        private BillingValidator CreateContaValidator()
        {
            return new BillingValidator();
        }

        [Fact]
        public void IsValid_ValidState_ReturnValidResult()
        {
            // Given
            var contaValidator = this.CreateContaValidator();
            Billing conta = new Billing {
                EndDate = DateTime.UtcNow.AddDays(30),
                BeneficiaryName = "empresa",
                Price = 123.99m,
                IsPaid = false
            };

            // Act
            var result = contaValidator.IsValid(conta);

            // Then
            Assert.True(result);            
        }        
        [Theory]
        [InlineData("")]        
        public void IsValid_InvalidNomeEmpresaState_ReturnError(string nomeEmpresa)
        {
            var contaValidator = this.CreateContaValidator();
            Billing conta = new Billing
            {
                EndDate = DateTime.UtcNow.AddDays(30),
                BeneficiaryName = nomeEmpresa,
                Price = 123.99m,
                IsPaid = false
            };

            // When
            var result = contaValidator.IsValid(conta);

            // Then
            Assert.False(result);
        }
        [Theory]
        [InlineData(-10)]
        [InlineData(0)]
        public void IsValid_InvalidValorState_ReturnError(decimal valor)
        {
            var contaValidator = this.CreateContaValidator();
            Billing conta = new Billing
            {
                EndDate = DateTime.UtcNow.AddDays(30),
                BeneficiaryName = "empresa",
                Price = valor,
                IsPaid = false
            };

            // When
            var result = contaValidator.IsValid(conta);

            // Then
            Assert.False(result);
        }
    }
}
