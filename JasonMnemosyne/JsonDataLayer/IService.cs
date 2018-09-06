using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JasonMnemosyne.JsonDataLayer
{
    public interface IService
    {
        void AddDataList<T>(List<T> dataList) where T : class;
        List<T> GetDataList<T>() where T : class;
    }
}
