using AData.SQLServer.Models;
using System.Collections.Generic;

namespace AData.Business.Interface
{
    public interface IBookAppSvc
    {
        void Create(Book book);

        IEnumerable<Book> GetAll();

        int GetCount();
    }
}
