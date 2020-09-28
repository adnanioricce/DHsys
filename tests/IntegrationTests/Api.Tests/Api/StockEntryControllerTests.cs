using Core.ApplicationModels.Dtos.Stock;
using Core.Entities.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tests.Lib;

namespace Api.Tests.Api
{
    public class StockEntryControllerTests : ControllerTestBase<StockEntry,StockEntryDto,Startup>
    {
        public StockEntryControllerTests(TestFixture<Startup> fixture) : base(fixture) { }
    }
}
