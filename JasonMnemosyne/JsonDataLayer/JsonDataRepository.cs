using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JasonMnemosyne.JsonDataLayer
{
    public class JsonDataRepository : IRepository
    {
        private readonly IConfiguration _config;

        public JsonDataRepository(IConfiguration config)
        {
            _config = config;
        }

        public void ListToJsonFile<T>(List<T> entryList) where T : class
        {
            var jsonDataFileName = _config[typeof(T).Name.ToString()];
            var appDomain = System.AppDomain.CurrentDomain;
            var basePath = appDomain.RelativeSearchPath ?? appDomain.BaseDirectory;
            File.WriteAllText(Path.Combine(basePath, "JsonDataLayer/JsonDataFiles", jsonDataFileName), JsonConvert.SerializeObject(entryList, Formatting.Indented));
   
        }

        public List<T> GetListFromJsonFile<T>() where T : class
        {
            var jsonDataFileName = _config[typeof(T).Name.ToString()];
            var appDomain = System.AppDomain.CurrentDomain;
            var basePath = appDomain.RelativeSearchPath ?? appDomain.BaseDirectory;
            List<T> dataList = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(Path.Combine(basePath, "JsonDataLayer/JsonDataFiles", jsonDataFileName)));

            return dataList;
        }
    }
}
