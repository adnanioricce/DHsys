using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.Extensions
{
    public static class AssemblyExtensions
    {
        public static IEnumerable<Type> GetTypesWithBaseType(this Assembly assembly,Type baseType)
        {
            return assembly
                    .GetTypes()
                    .Where(t => t.IsClass && !t.IsAbstract && (t.BaseType is null ? false : t.BaseType.IsGenericType))
                    .Where(t => t.BaseType.GetGenericTypeDefinition() == baseType);
        }
        
    }
}
