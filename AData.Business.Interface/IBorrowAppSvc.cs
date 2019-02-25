using AData.MySQL;
using System.Collections.Generic;

namespace AData.Business.Interface
{
    public interface IBorrowAppSvc
    {
        void Create(borrows borrows);

        IEnumerable<borrows> GetAll();

        int GetCount();
    }
}
