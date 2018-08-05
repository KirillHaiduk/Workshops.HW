using System.Collections.Generic;

namespace ReflectionTask
{
    /// <summary>
    /// Represents generic comparer based on reflection.
    /// </summary>
    /// <typeparam name="T">Parameter type.</typeparam>
    /// <seealso cref="System.Collections.Generic.IEqualityComparer{T}" />
    public class CustomComparer<T> : IEqualityComparer<T>
    {
        private IList<string> propertyList = new List<string>();

        private PropertyExtractor propertyExtractor;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomComparer{T}"/> class.
        /// </summary>
        public CustomComparer()
        {
            this.propertyExtractor = new PropertyExtractor();
            this.propertyList = propertyExtractor.GetPropertyNames<T>();
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="x">The first object of type <paramref name="T" /> to compare.</param>
        /// <param name="y">The second object of type <paramref name="T" /> to compare.</param>
        /// <returns>
        ///   <see langword="true" /> if the specified objects are equal; otherwise, <see langword="false" />.
        /// </returns>
        public bool Equals(T x, T y)
        {
            if (x == null)
            {
                return y == null;
            }

            if (x.GetType() != y.GetType())
            {
                return false;
            }

            foreach (var propertyName in this.propertyList)
            {
                string xValue = propertyExtractor.GetPropertyValue(propertyName, x);
                string yValue = propertyExtractor.GetPropertyValue(propertyName, y);
                if (!xValue.Equals(yValue))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public int GetHashCode(T obj)
        {
            int hash = 17;
            foreach (var propertyInfo in this.propertyList)
            {
                var propertyValue = propertyExtractor.GetPropertyValue(propertyInfo, obj);
                hash = hash * 23 + propertyValue.GetHashCode();
            }

            return hash;
        }
    }    
}
