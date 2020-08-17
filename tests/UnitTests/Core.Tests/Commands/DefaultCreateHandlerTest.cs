using Core.Commands.Default;
using Core.Entities;
using Core.Entities.Financial;
using Core.Handlers;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Tests.Lib.Data;
using Xunit;

namespace Core.Tests.Commands
{
    public class DefaultCreateHandlerTest
    {
        [Fact]
        public async Task Given_create_method_to_save_BaseEntity_object_When_receives_object_Then_try_insert_object()
        {
            // Given 
            var entity = new Billing
            {
                BeneficiaryId = 1,
                BeneficiaryName = "FAKE BENEFICIARY",
                CreatedAt = DateTimeOffset.UtcNow,
                Discount = 1,
                EndDate = DateTime.UtcNow,
                PersonType = PersonDocumentType.Cpf,
                Price = 12.99m,
                UniqueCode = Guid.NewGuid().ToString(),
                IsPaid = true,                
            };
            var request = new DefaultCreateRequest<Billing>
            {
                Entity = entity
            };
            var fakeRepository = new FakeRepository<Billing>();
            var handler = new DefaultCreateHandler<Billing>(fakeRepository);
            // When
            var result = await handler.Handle(request,default(CancellationToken));
            // Then
            Assert.Equal(Unit.Value,result);
        }
    }
}
