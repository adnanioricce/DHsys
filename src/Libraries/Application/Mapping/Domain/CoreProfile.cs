using AutoMapper;
using Core.ApplicationModels.Dtos.Catalog;
using Core.Entities.Catalog;
using System;
using System.Linq;
using System.Reflection;
using Core;
using System.Collections.Generic;

namespace Application.Mapping.Domain
{
    public class CoreProfile : Profile
    {
        public CoreProfile()
        {
            var coreTypes = Assembly.GetAssembly(typeof(Core.Core))
                                    .GetTypes()
                                    .Where(IsDefinedType)
                                    .ToList();
            var entities = coreTypes.Where(t => t.Namespace.StartsWith("Core.Entities"));                                 
            var dtos = coreTypes.Where(t => t.Namespace.StartsWith("Core.ApplicationModels.Dtos"));
            foreach (var entity in entities)
            {
                var dto = dtos.Where(d => string.Equals(d.Name.Replace("Dto","").ToLower(),entity.Name.ToLower())).FirstOrDefault();
                if(dto is null)
                {
                    continue;
                }
                var map = CreateMap(dto, entity).MaxDepth(0).ReverseMap();                
            }
            bool IsDefinedType(Type type) => !String.IsNullOrEmpty(type.Namespace);
        }
    }
}
