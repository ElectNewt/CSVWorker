using System;

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CSV.Test")]
namespace CSV.TypeConverter
{
    internal class FloatConverter : BaseConverter
    {
        public FloatConverter(object value) : base(value)
        {
        }

        public override object ConvertToObject(string format, IFormatProvider provider)=> Convert.ToSingle(Value, provider);
     

        public override string GetString(string format, IFormatProvider provider)=> Convert.ToSingle(Value).ToString(format, provider);

    }
}
