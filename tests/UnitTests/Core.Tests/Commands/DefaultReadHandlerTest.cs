using AutoMapper;
using Core.Commands.Default;
using Core.Entities;
using Core.Entities.Financial;
using Core.Handlers;
using Core.Models.ApplicationResources;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Tests.Lib.Data;
using Xunit;

namespace Core.Tests.Commands
{
    public class DefaultReadHandlerTest
    {
        [Fact]
        public async Task Given_record_save_on_database_When_receives_id_of_record_Then_return_entity_object_of_the_record_id()
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
            var fakeRepository = new FakeRepository<Billing>(new[] { entity });            
            var fakeMapper = new Mock<IMapper>();
            fakeMapper.Setup(m => m.Map<BaseResourceResponse<Billing>>(It.IsAny<Billing>()))
                .Returns(new BaseResourceResponse<Billing>
                {
                    ResultObject = entity,
                    Success = true,
                    Message = "no error"
                });
            var handler = new DefaultReadHandler<Billing, BaseResourceResponse<Billing>>(fakeRepository,fakeMapper.Object);
            var request = new DefaultReadRequest<Billing, BaseResourceResponse<Billing>>
            {
                Id = entity.Id
            };
            // When            
            var result = await handler.Handle(request, default(CancellationToken));
            // Then
            Assert.True(result.Success);
            Assert.Equal(1, result.ResultObject.Id);

        }
    }
}
