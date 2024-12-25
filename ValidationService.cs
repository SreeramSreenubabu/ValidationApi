using System;
using System.Linq;
using System.Reflection;
using YourNamespace.Attributes;

namespace YourNamespace.Services
{
    public class ValidationService
    {
        public void ValidateRequestData<T>(T requestData)
        {
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                var value = property.GetValue(requestData);

                // Check for Required attribute
                if (Attribute.IsDefined(property, typeof(RequiredAttribute)))
                {
                    if (value == null || (property.PropertyType == typeof(string) && string.IsNullOrEmpty((string)value)))
                    {
                        throw new ArgumentException($"{property.Name} is required.");
                    }

                    if (property.PropertyType == typeof(DateTime) && (DateTime)value == default(DateTime))
                    {
                        throw new ArgumentException($"{property.Name} is required.");
                    }

                    if (property.PropertyType == typeof(int) && (int)value == 0)
                    {
                        throw new ArgumentException($"{property.Name} is required.");
                    }
                }

                // Check for MaxLength attribute
                var maxLengthAttribute = property.GetCustomAttribute<MaxLengthAttribute>();
                if (maxLengthAttribute != null && value is string stringValue)
                {
                    if (stringValue.Length > maxLengthAttribute.Length)
                    {
                        throw new ArgumentException($"{property.Name} exceeds maximum length of {maxLengthAttribute.Length}.");
                    }
                }
            }
        }
    }
}
