using Core.ApplicationModels.Dtos.Stock;
using Core.Entities.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tests.Lib;

namespace Api.Tests
{
    public class SupplierControllerTests : ControllerTestBase<Supplier,SupplierDto>
    {
        public SupplierControllerTests(ApiTestFixture fixture) : base(fixture) { }
    }
}
