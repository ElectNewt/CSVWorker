using System;

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CSV.Test")]
namespace CSV.TypeConverter
{
    internal class LongConverter : BaseConverter
    {
        public LongConverter(object value) : base(value)
        {
        }

        public override object ConvertToObject(string format, IFormatProvider provider)=> Convert.ToInt64(Value, provider);
        public override string GetString(string format, IFormatProvider provider)=> Convert.ToInt64(Value).ToString(format, provider);
      
    }
}
