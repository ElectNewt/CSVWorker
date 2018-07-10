using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CSV.Test")]
namespace CSV.TypeConverter
{
    internal class TimesSpanConverter : BaseConverter
    {
        public TimesSpanConverter(object value) : base(value)
        {
        }

        public override object ConvertToObject(string format, IFormatProvider provider) => TimeSpan.ParseExact(Value.ToString(), format, provider);

        public override string GetString(string format, IFormatProvider provider)=>TimeSpan.Parse(Value.ToString()).ToString(format, provider);
    
    }
}
