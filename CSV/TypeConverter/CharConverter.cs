using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CSV.Test")]
namespace CSV.TypeConverter
{
    internal class CharConverter : BaseConverter
    {
        public CharConverter(object value) : base(value)
        {
        }

        public override object ConvertToObject(string format, IFormatProvider provider) => Convert.ToChar(Value, provider);
        

        public override string GetString(string format, IFormatProvider provider)=> Convert.ToChar(Value).ToString(provider);
    }
}
