using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ReflectionTask
{
    /// <summary>
    /// Represents methods for extracting properties and values from instance.
    /// </summary>
    public class PropertyExtractor
    {
        /// <summary>
        /// Gets the property names.
        /// </summary>
        /// <typeparam name="T">Parameter type.</typeparam>
        /// <returns>Sequence of property names.</returns>
        public IList<string> GetPropertyNames<T>()
        {
            IList<string> propertyNames = new List<string>();
            var propertyInfos = typeof(T).GetProperties(
                BindingFlags.Public |
                BindingFlags.Static |
                BindingFlags.NonPublic |
                BindingFlags.Default |
                BindingFlags.Instance).ToList();

            if (propertyInfos.ToList().Count > 0)
            {
                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    propertyNames.Add(propertyInfo.Name);
                }
            }

            return propertyNames;
        }

        /// <summary>
        /// Gets the property value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="entity">The source.</param>
        /// <returns>Value of instance property as string.</returns>
        public string GetPropertyValue<T>(string propertyName, T entity) => entity.GetType().GetProperty(propertyName).GetValue(entity, null).ToString();
    }
}
