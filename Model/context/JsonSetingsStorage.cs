using System;
using System.IO;
using System.Runtime.Serialization.Json;

namespace HtlWeiz.WkstPlaner.Model.context
{
    public class  JsonSetingsStorage<T> : ISetingsStorage<T>
    {
        private readonly string _path;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filepath">Path to the file to be stored</param>
        /// <param name="filename">Filename without extension</param>
        public JsonSetingsStorage(string filepath, string filename)
        {
            if (string.IsNullOrEmpty(filepath))
            {
                throw new ArgumentOutOfRangeException(nameof(filepath), "Filepath must be set");
            }
            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentOutOfRangeException(nameof(filename),"Filename must be set");
            }

            _path = Path.Combine(filepath, filename + ".json");
        }

        public void WriteSettings( T settings)
        {
            using (var fileStream = File.Create(_path))
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                serializer.WriteObject(fileStream, settings);
            }


        }

        public void ReadSettingsTo(ref T settings)
        {
            if (!File.Exists(_path)) return;

            using (var fileStream = File.OpenRead(_path))
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                settings = (T)serializer.ReadObject(fileStream);
            }
        }

    }


}
