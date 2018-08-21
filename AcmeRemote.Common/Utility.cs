using AcmeRemote.BusinessEntity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AcmeRemote.Common
{
    public static class Utility
    {
        private static string _fileBasePath = AppDomain.CurrentDomain.BaseDirectory + @"\bin\";
        public static void SaveFile(string fileName, object data)
        {
            using (StreamWriter sw = File.CreateText(_fileBasePath + fileName))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(writer, data);
            }
        }

        public static T Read<T>(string fileName)
        {
            using (StreamReader file = File.OpenText(_fileBasePath + fileName))
            {
                var json = file.ReadToEnd();
                json = Regex.Unescape(json);
                var result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
        }
    }
}
