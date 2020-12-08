using AutoMapper;
using System.Linq;
using System.Reflection;

namespace Application.Mapping.Domain
{
    public class CoreProfile : Profile
    {
        public CoreProfile()
        {
            var coreTypes = Assembly.GetAssembly(typeof(Core.Core))
                                    .GetTypes();
            var entities = coreTypes.Where(t => t.Namespace.StartsWith("Core.Entities"));
            var dtos = coreTypes.Where(t => t.Namespace.StartsWith("Core.ApplicationModels.Dtos"));
            foreach (var entity in entities)
            {
                var dto = dtos.Where(d => string.Equals(d.Name.Replace("Dto","").ToLower(),entity.Name.ToLower())).FirstOrDefault();
                if(dto is null)
                {
                    continue;
                }
                var map = CreateMap(dto, entity);                
                CreateMap(entity, dto);
            }

        }
    }
}
