using System.Linq;

namespace Core.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsNumber(this object value)
        {
            return value is sbyte
                    || value is byte
                    || value is short
                    || value is ushort
                    || value.GetType() == typeof(int)
                    || value is uint
                    || value is long
                    || value is ulong
                    || value is float
                    || value is double
                    || value is decimal;
        }
        public static bool MapObjectFrom(this object source,object destination)
        {
            var updatedProperties = 0;
            var simpleProperties = destination.GetType()
                  .GetProperties()
                  .Where(p => p.GetType().IsValueType);
            var objectProperties = destination.GetType()
                                              .GetProperties()
                                              .Where(p => !p.GetType().IsValueType && p.GetType().IsArray);
            foreach (var sourceProperty in source.GetType()
                                                 .GetProperties()) {
                if (sourceProperty.GetType().IsValueType) {
                    if (simpleProperties.Any(sp => sp.GetValue(destination) != sourceProperty.GetValue(source))) {
                        var updatedProperty = simpleProperties.Where(sp => sp.Name == sourceProperty.Name)
                                                              .FirstOrDefault();
                        sourceProperty.SetValue(source, updatedProperty.GetValue(destination));
                        updatedProperties++;
                    }
                }
            }
            return updatedProperties > 0;
        }
    }
}