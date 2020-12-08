using Core.ApplicationModels.Dtos.Catalog;
using Core.Entities.Catalog;

namespace Api.Tests
{
    public class CategoryControllerTests : ControllerTestBase<Category, CategoryDto>
    {
        public CategoryControllerTests(ApiTestFixture fixture) : base(fixture)
        {
        }
    }
}
