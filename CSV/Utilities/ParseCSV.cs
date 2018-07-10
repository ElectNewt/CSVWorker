using CSV.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CSV.Utilities
{
    internal class ParseCsv
    {
        CsvReaderConfiguration _configuration = new CsvReaderConfiguration();
        public ParseCsv(CsvReaderConfiguration config)
        {
            _configuration = config;
        }

        public IEnumerable<IList<string>> FromFile(string fileName)
        {
            foreach (IList<string> item in FromFile(fileName, _ignoreFirstLineDefault)) yield return item;
        }

        public IEnumerable<IList<string>> FromFile(string fileName, bool ignoreFirstLine)
        {
            using (StreamReader rdr = new StreamReader(fileName))
            {
                foreach (IList<string> item in FromReader(rdr, ignoreFirstLine)) yield return item;
            }
        }

        public IEnumerable<IList<string>> FromStream(Stream csv)
        {
            foreach (IList<string> item in FromStream(csv, _ignoreFirstLineDefault)) yield return item;
        }

        public IEnumerable<IList<string>> FromStream(Stream csv, bool ignoreFirstLine)
        {
            using (var rdr = new StreamReader(csv))
            {
                foreach (IList<string> item in FromReader(rdr, ignoreFirstLine)) yield return item;
            }
        }

        public IEnumerable<IList<string>> FromReader(TextReader csv)
        {
            foreach (IList<string> item in FromReader(csv, _ignoreFirstLineDefault)) yield return item;
        }

        public IEnumerable<IList<string>> FromReader(TextReader csv, bool ignoreFirstLine)
        {
            if (ignoreFirstLine) csv.ReadLine();

            StringBuilder curValue = new StringBuilder();
            string row;
            while ((row = csv.ReadLine()) != null)
            {
                IList<string> result = new List<string>();
                var isQuote = false;
                var isSentence = false;
                var sentence = new StringBuilder();
                //tried to do before with stringbuilder.peek on the (stringbuilder)row but it was skiiping the last character in some csvs i tested.
                foreach (char c in row)
                {
                    if (c == _configuration.GetDelimiter() && !isQuote && !isSentence)
                    {
                        sentence.Append("");
                    }

                    if (c == _configuration.GetDelimiter() &&!isQuote && isSentence )
                    {
                        isSentence = false;
                        result.Add(sentence.ToString());
                        sentence = new StringBuilder();
                    }
                    else if (_configuration.GetQualifiedText() == c && !isQuote)
                    {
                        isQuote = true;
                        if (!isSentence)
                            sentence = new StringBuilder();
                        else
                            sentence.Append(c);
                    }
                    else if (_configuration.GetQualifiedText() == c && isQuote)
                    {
                        isQuote = false;
                        if(isSentence)
                            sentence.Append(c);

                    }else if (isQuote)
                    {
                        sentence.Append(c);
                    }
                    else
                    {
                        isSentence = true;
                        sentence.Append(c);
                    }
                }
                if (sentence.Length > 0)
                    result.Add(sentence.ToString());

                yield return result;
            }
        }
        private static bool _ignoreFirstLineDefault = false;
    }
}
