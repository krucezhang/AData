using AData.Console.MSSQL.Controllers;
using System;
using System.Globalization;
using System.Threading;

namespace AData.Console.MSSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("zh-CN");
            System.Console.WriteLine("***************欢迎进入图书馆数据自动生成工具******************");
            System.Console.WriteLine("");
            System.Console.WriteLine("");
            System.Console.WriteLine("**当前数据情况如下：------------------------------");
            GetDBRecordCount();
            SimpleFactoryConsoleUI();
        }

        static void GetDBRecordCount()
        {
            System.Console.WriteLine("");
            System.Console.WriteLine(string.Format("1. 表Student(学生表)记录数为: {0}", CtrlFactory.StudentCtrl.Count));
            System.Console.WriteLine(string.Format("2. 表Book(书籍表)记录数为: {0}", CtrlFactory.BookCtrl.Count));
            System.Console.WriteLine(string.Format("3. 表Mangers(管理员表)记录数为: {0}", CtrlFactory.ManagerCtrl.Count));
            System.Console.WriteLine(string.Format("4. 表Borrow(学生借阅表)记录数为: {0}", CtrlFactory.BorrowCtrl.Count));
            System.Console.WriteLine(string.Format("5. 表ReturnBook(归还表)记录数为: {0}", CtrlFactory.ReturnBookCtrl.Count));
            System.Console.WriteLine(string.Format("0. 退出!"));
            System.Console.WriteLine("");
        }

        static void SimpleFactoryConsoleUI()
        {
            while (true)
            {
                System.Console.WriteLine("需要为哪个表添加记录，请输入选择序号和添加的记录数(逗号分隔)：");
                string inputValue = System.Console.ReadLine();
                int no, recordNumber;
                HandlerInputValue(inputValue, out no, out recordNumber);

                if (no == 0)
                {
                    Exists();
                    break;
                }
                SimpleFactory(no, recordNumber);
            }
        }

        private static void HandlerInputValue(string inputValue, out int no, out int recordNumber)
        {
            var values = inputValue.Split(',');
            no = StringToInt(values[0]);
            recordNumber = 0;
            if (values.Length == 2)
            {
                recordNumber = StringToInt(values[1]);
            }
        }

        static void SimpleFactory(int number, int recordNumber)
        {
            System.Console.WriteLine("");
            System.Console.WriteLine(String.Format("选择的序号为:{0},添加的记录数为:{1}", number, recordNumber));
            System.Console.WriteLine("");
            if (recordNumber == 0)
            {
                GetDBRecordCount();
                return;
            }
            switch (number)
            {
                case 1:
                    CtrlFactory.StudentCtrl.Post(recordNumber);
                    break;
                case 2:
                    CtrlFactory.BookCtrl.Post(recordNumber);
                    break;
                case 3:
                    CtrlFactory.ManagerCtrl.Post(recordNumber);
                    break;
                case 4:
                    CtrlFactory.BorrowCtrl.Post(recordNumber);
                    break;
                case 5:
                    CtrlFactory.ReturnBookCtrl.Post(recordNumber);
                    break;
                default:
                    System.Console.WriteLine("应该输入0-5之间的选项");
                    break;
            }
            GetDBRecordCount();
        }

        private static void Exists()
        {
            System.Console.WriteLine("Press any key to continue . . . ");
            System.Console.ReadKey(true);
        }

        private static int StringToInt(string value = "")
        {
            int recordNo = 0;
            int result = 0;
            if (Int32.TryParse(value, out recordNo))
            {
                result = recordNo;
            }

            return result;
        }
    }
}
