using Core.Entities.LegacyScaffold;
using System;
using Xunit;

namespace Services.Tests
{
    public class LegacyDataMapperTest
    {
        [Fact]
        public void MapToDomainModel_ReceivesObjectWithLegacyEntityModel_ShouldReturnVersionOfTheEntityOnCurrentModel()
        {
            //Given
            var legacyEntity = new Produto
            {
                Coddcb = "",
                Codesta = "",
                Codfis = "",
                Comissao = 1.2,
                DescMax = 1.0,
                EstMinimo = 1,
                Etbarra = "",
                Etgraf = "",
                Prbarra = "",
                Prcddt = DateTime.UtcNow,
                P
            };
            //{

            //}
        }
    }
}
