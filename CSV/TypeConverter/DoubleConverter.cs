using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CSV.Test")]
namespace CSV.TypeConverter
{
    internal class DoubleConverter : BaseConverter
    {
        public DoubleConverter(object value) : base(value)
        {
        }

        public override object ConvertToObject(string format, IFormatProvider provider)=> Convert.ToDouble(Value, provider);

        public override string GetString(string format, IFormatProvider provider) =>  Convert.ToDouble(Value, provider).ToString(format,provider);
        
    }
}
