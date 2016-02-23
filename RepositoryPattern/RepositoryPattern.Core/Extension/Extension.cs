namespace RepositoryPattern.Core.Extension
{
    public static class Extension
    {
        /// <summary>
        /// Determines whether [is null or default] [the specified value].
        /// </summary>
        /// <typeparam name="T"> The generic type. </typeparam>
        /// <param name="value"> The value. </param>
        /// <returns> The object is null or default. </returns>
        public static bool IsNullOrDefault<T>(this T value) where T : class
        {
            var result = value == null || value.Equals(default(T));
            return result;
        }
    }
}