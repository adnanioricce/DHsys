using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Application.Mapping.Domain
{
    /// <summary>
    /// Profile with mapping between own types, to handle updates.
    /// <para>ie: Product -> Product , Supplier -> Supplier</para>
    /// </summary>
    public class UpdateProfile : Profile
    {
        public UpdateProfile()
        {
            foreach(var entity in Assembly.GetAssembly(typeof(Core.Core))
                                    .GetTypes()
                                    .Where(t => t.Namespace.StartsWith("Core.Entities")))
            {
                var map = CreateMap(entity, entity);
                foreach (var property in entity.GetProperties())
                {
                    if (typeof(ICollection<>).IsAssignableFrom(property.PropertyType) || typeof(IList<>).IsAssignableFrom(property.PropertyType))
                    {
                        map.ForMember(property.Name, opt => opt.Ignore());
                    }
                    else if (!property.PropertyType.IsValueType)
                    {
                        map.ForMember(property.Name, opt => opt.Ignore());
                    }
                }
            }            
        }
    }
}
