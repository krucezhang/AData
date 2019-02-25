using AData.MySQL;
using System.Collections.Generic;

namespace AData.Business.Interface
{
    public interface IReturnBookAppSvc
    {
        void Create(returnbooks returnbook);

        IEnumerable<returnbooks> GetAll();

        int GetCount();
    }
}
