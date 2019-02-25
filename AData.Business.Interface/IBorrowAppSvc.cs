using AData.MySQL;
using System.Collections.Generic;

namespace AData.Business.Interface
{
    public interface IBorrowAppSvc
    {
        void Create(int count);

        IEnumerable<borrows> GetAll();

        int GetCount();
    }
}
