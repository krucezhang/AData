using AData.MongoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AData.Business.Interface
{
    public interface ICategoryAppSvc
    {
        void Create(Category category);

        IEnumerable<Category> GetAll();

        int GetCount();
    }
}
