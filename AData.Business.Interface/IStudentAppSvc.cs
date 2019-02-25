using AData.MySQL;
using AData.SQLServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AData.Business.Interface
{
    public interface IStudentAppSvc
    {
        void Create(Student student);

        IEnumerable<Student> GetAll();

        int GetCount();
    }
}
