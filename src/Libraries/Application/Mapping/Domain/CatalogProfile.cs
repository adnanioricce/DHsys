using Application.Dtos.Catalog;
using AutoMapper;
using Core.ApplicationModels.Dtos.Catalog;
using Core.Entities.Catalog;

namespace Application.Mapping.Domain
{
    public class CatalogProfile : Profile
    {
        public CatalogProfile()
        {
            CreateMap<Drug, DrugDto>();
            CreateMap<DrugDto, Drug>();
        }
    }
}
