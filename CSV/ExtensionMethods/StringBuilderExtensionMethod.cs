using System.Text;

namespace CSV.ExtensionMethods
{
    public static class StringBuilderExtensionMethod
    {
        /// <summary>
        /// append a caracter at the end of a string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="delimiter"></param>
        public static void AppendDelimitter(this StringBuilder str, char delimiter)
        {
            if (str.Length != 0)
            {
                str.Append(delimiter);
            }
        }
    }
}
