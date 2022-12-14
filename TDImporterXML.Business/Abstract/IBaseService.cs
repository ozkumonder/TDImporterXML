using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDImporterXML.Business.Abstract
{
    public interface IBaseService<T>
    {
        List<T> GetAll();
        T GetEntity();
        T AddEntity();
        bool UpdateEntity();
        bool DeleteEntity();
    }
}
