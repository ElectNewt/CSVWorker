using System;

namespace CSV.Configuration
{
    public class CsvBaseConfiguration <T> where T : CsvBaseConfiguration<T>
    {
        private Boolean _containsHeaders;
        private char _delimiter;
        private char _qualifiedText;

        public CsvBaseConfiguration()
        {
            SetContainsHeaders(false);
            SetDelimiter(',');
            SetQualifiedText('"');
        }

        internal char GetDelimiter() => _delimiter;
        internal bool GetContainsHeaders() => _containsHeaders;
        internal char GetQualifiedText() => _qualifiedText;


        public T SetDelimiter(char delimiter)
        {
            _delimiter = delimiter;
            return (T)this; 
        }
        public T SetQualifiedText(char value)
        {
            _qualifiedText = value;
            return (T)this;
        }

        public T SetContainsHeaders(bool containsHeaders)
        {
            _containsHeaders = containsHeaders;
            return (T)this;
        }

    }
}
