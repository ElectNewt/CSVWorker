using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CSV.Test")]
namespace CSV.TypeConverter
{
    internal interface ITypeConverter
    {
        /// <summary>
        /// Conver to the specified object type
        /// </summary>
        /// <param name="format"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        object ConvertToObject(string format, IFormatProvider provider);

        /// <summary>
        /// get a string based on an object
        /// </summary>
        /// <param name="format"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        string GetString(string format, IFormatProvider provider);
    }
}
