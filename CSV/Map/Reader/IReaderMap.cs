using CSV.Map.Common;
using System;
using System.Reflection;

namespace CSV.Map
{
    public interface IReaderMap<T>
    {
        /// <summary>
        /// Check if is the correct property
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        bool IsProperty(PropertyInfo property);

        /// <summary>
        /// Get index position
        /// </summary>
        /// <returns></returns>
        int GetPosition();

        /// <summary>
        /// Get property name
        /// </summary>
        /// <returns></returns>
        string GetPropertyName();

        /// <summary>
        /// get format, includint the string as format and the provider
        /// </summary>
        /// <returns></returns>
        Formatter Format();

        /// <summary>
        /// Assign format to the field and format provider
        /// </summary>
        /// <param name="format">string</param>
        /// <param name="provider">new format provider</param>
        void Format(string format, IFormatProvider provider);

        /// <summary>
        /// Assign format to the field
        /// </summary>
        /// <param name="format"></param>
        void Format(string format);

        /// <summary>
        /// set provider for the field.
        /// </summary>
        /// <param name="provider"></param>
        void Format(IFormatProvider provider);

    }
}
