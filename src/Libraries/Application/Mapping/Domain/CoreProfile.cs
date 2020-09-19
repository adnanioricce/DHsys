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
                var dto = dtos.Where(d => d.Name.StartsWith(entity.Name)).FirstOrDefault();
                if(dto is null)
                {
                    continue;
                }
                CreateMap(dto, entity);
                CreateMap(entity, dto);
            }

        }
    }
}
