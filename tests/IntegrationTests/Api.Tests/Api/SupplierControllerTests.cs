using Core.ApplicationModels.Dtos.Stock;
using Core.Entities.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tests.Lib;

namespace Api.Tests.Api
{
    public class SupplierControllerTests : ControllerTestBase<Supplier,SupplierDto,Startup>
    {
        public SupplierControllerTests(TestFixture<Startup> fixture) : base(fixture) { }
    }
}
