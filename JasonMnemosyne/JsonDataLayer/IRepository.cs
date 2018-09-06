using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JasonMnemosyne.JsonDataLayer
{
    public interface IRepository
    {
        void ListToJsonFile<T>(List<T> entryList) where T : class;
        List<T> GetListFromJsonFile<T>() where T : class;
    }
}
