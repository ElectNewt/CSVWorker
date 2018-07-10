using System;
using System.IO;

namespace CSV.Utilities
{
    public class CreateDirectory
    {
        private string Path { get; set; }

        public CreateDirectory(string path)
        {
            Path = path;
        }

        /// <summary>
        /// Create directory based on a path
        /// </summary>
        public void Create()
        {
            try
            {
                var directory = new FileInfo(Path).Directory.FullName;
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
