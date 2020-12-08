using AutoMapper;
using Core.ApplicationModels.Dtos.Catalog;
using Core.Entities.Catalog;
using Core.Interfaces;
using Core.Validations;

namespace Api.Controllers.Api
{
    public class CategoryController : DefaultApiController<Category, CategoryDto>
    {
        public CategoryController(IRepository<Category> repository, IMapper mapper, BaseValidator<Category> validator) : base(repository, mapper, validator)
        {
        }
    }
}
