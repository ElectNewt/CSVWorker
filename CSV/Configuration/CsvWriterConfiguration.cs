namespace CSV.Configuration
{
    public class CsvWriterConfiguration : CsvBaseConfiguration <CsvWriterConfiguration>
    {
        private bool _createDirectory { get; set; }
        private string _emptyFilesExtension { get; set; }


        public CsvWriterConfiguration() {
            SetCreateDirectory(false);
            SetEmptyFilesExtension("");
        }

        internal bool CreateDirectory
        {
            get => _createDirectory;
            set => _createDirectory = value;
        }

        internal string EmptyFilesExtension
        {
            get => _emptyFilesExtension;
            set => _emptyFilesExtension = value;
        }

        public CsvWriterConfiguration SetCreateDirectory(bool createDirectory)
        {
            _createDirectory = createDirectory;
            return this;
        }
        public CsvWriterConfiguration SetEmptyFilesExtension(string extension) {
            _emptyFilesExtension = extension;
            return this;
        }


    }
}
