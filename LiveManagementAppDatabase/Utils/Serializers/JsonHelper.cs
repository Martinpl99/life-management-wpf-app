using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LiveManagementAppDatabase.Utils.Serializers
{
    internal static class JsonHelper
    {
        public static string Serialize<T>(T obj)
        {
            return JsonSerializer.Serialize(obj, options: JsonSerializerOptions.Web);
        }

        public static async Task<T> DeserializeAsync<T>(Stream? stream)
        {
            return await JsonSerializer.DeserializeAsync<T>(stream, options: JsonSerializerOptions.Web);
        }
    }
}
