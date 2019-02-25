using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AData.Console.MSSQL.Controllers
{
    public static class CtrlFactory
    {
        public static BookController BookCtrl
        {
            get
            {
                return new BookController();
            }
        }

        public static StudentController StudentCtrl
        {
            get
            {
                return new StudentController();
            }
        }

        public static CategoryController CategoryCtrl
        {
            get
            {
                return new CategoryController();
            }
        }

        public static ManagerController ManagerCtrl
        {
            get
            {
                return new ManagerController();
            }
        }

        public static BorrowController BorrowCtrl
        {
            get
            {
                return new BorrowController();
            }
        }

        public static ReturnBookController ReturnBookCtrl
        {
            get
            {
                return new ReturnBookController();
            }
        }
    }
}
