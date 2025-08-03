using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Doglibrary_management
{
    public class FileContext
    {
        public void SaveToFile<T>(string path, List<T> data)
        {
            File.WriteAllText(path, JsonSerializer.Serialize(data));
        }

        public List<T> LoadFromFile<T>(string path)
        {
            if (!File.Exists(path)) return new List<T>();
            return JsonSerializer.Deserialize<List<T>>(File.ReadAllText(path)) ?? new List<T>();
        }
    }
}
