using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CSV.Test")]
namespace CSV.TypeConverter
{
    internal class StringConverter : BaseConverter
    {
        public StringConverter(object value) : base(value)
        { }

        public override object ConvertToObject(string format, IFormatProvider provider) => Value.ToString();
        public override string GetString(string format, IFormatProvider provider) => Value.ToString();
    
    }
}
