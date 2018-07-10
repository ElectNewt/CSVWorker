using CSV.Map.Common;
using System;
using System.Reflection;

namespace CSV.Map.Writer
{
    public interface IWriterMap <T>
    {
        /// <summary>
        /// Assign format to the field and specify the format provider.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="provider">IFormatProvider</param>
        /// <returns></returns>
        IWriterMap<T> Format(string format, IFormatProvider provider);
        /// <summary>
        /// Assign format to the field
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        IWriterMap<T> Format(string format);
        /// <summary>
        /// Specify the format provider
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        IWriterMap<T> Format(IFormatProvider provider);
        /// <summary>
        /// Set the position for a field
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        IWriterMap<T> Position(int index);
        /// <summary>
        /// Set the header name of a field
        /// </summary>
        /// <param name="headerName"></param>
        /// <returns></returns>
        IWriterMap<T> HeaderName(string headerName);
        /// <summary>
        /// Set if the field has to be visible in the csv
        /// </summary>
        /// <param name="visibility"></param>
        /// <returns></returns>
        IWriterMap<T> Visible(bool visibility);

        /// <summary>
        /// Get the current format, which contains the format and the provider
        /// </summary>
        /// <returns></returns>
        Formatter Format();
        /// <summary>
        /// Get the position of the field
        /// </summary>
        /// <returns></returns>
        int Position();
        /// <summary>
        /// Get the header name
        /// </summary>
        /// <returns></returns>
        string HeaderName();
        /// <summary>
        /// Get if is visible
        /// </summary>
        /// <returns></returns>
        bool Visible();
        /// <summary>
        /// Get property information.
        /// </summary>
        /// <returns></returns>
        PropertyInfo GetProperty();

    }
}
