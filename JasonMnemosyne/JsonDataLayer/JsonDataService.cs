using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JasonMnemosyne.JsonDataLayer
{
    public class JsonDataService :IService
    {
        private IRepository _repository;

        public JsonDataService(IRepository repository)
        {
            _repository = repository;
        }

        public void AddDataList<T>(List<T> dataList) where T : class
        {
            _repository.ListToJsonFile<T>(dataList);
        }

        public List<T> GetDataList<T>() where T : class
        {
            List<T> dataList = _repository.GetListFromJsonFile<T>();
            return dataList;
        }
    }
}
