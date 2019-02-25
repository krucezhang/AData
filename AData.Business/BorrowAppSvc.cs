using AData.Business.Interface;
using AData.Common.Extensions;
using AData.MySQL;
using AData.Persistence.Interface;
using AData.SQLServer.Models;
using DataGenerator;
using DataGenerator.Sources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AData.Business
{
    public class BorrowAppSvc : IBorrowAppSvc
    {
        private IUnitOfWork unitOfWork;
        private IRepository<borrows> borrowsRepository;
        private IRepository<Student> studentRepository;
        private IRepository<Book> bookRepository;

        public BorrowAppSvc(IUnitOfWork unitOfWork
            , IRepository<borrows> borrowsRepository
            , IRepository<Student> studentRepository
            , IRepository<Book> bookRepository)
        {
            this.unitOfWork = unitOfWork;

            this.borrowsRepository = borrowsRepository;
            this.borrowsRepository.UnitOfWork = unitOfWork;

            this.studentRepository = studentRepository;
            this.studentRepository.UnitOfWork = unitOfWork;

            this.bookRepository = bookRepository;
            this.bookRepository.UnitOfWork = unitOfWork;
        }

        public void Create(int count)
        {
            var studentIds = this.GetStudentIds();
            var bookIds = this.GetBookIds();

            var expectRetutrnDays = new List<int> { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };

            var generator = Generator.Create(c =>
                c.Entity<borrows>(e =>
                {
                    e.Property(p => p.BookId).DataSource(bookIds);
                    e.Property(p => p.StudentId).DataSource(studentIds);
                    e.Property(p => p.BorrowDate).DateTimeSource(new DateTime(2018, 1, 1), new DateTime(2019, 12, 12));
                    e.Property(p => p.ExpectReturnDate).Value(u => u.BorrowDate.AddDays(expectRetutrnDays.RandomList()));
                })
            );

            var borrowRecords = generator.List<borrows>(count);

            this.unitOfWork.ProcessWithTransaction(() =>
            {
                foreach (borrows item in borrowRecords)
                {
                    this.borrowsRepository.Add(item);
                    System.Console.WriteLine(JsonConvert.SerializeObject(item));
                }
            });
        }

        public IEnumerable<borrows> GetAll()
        {
            return this.borrowsRepository.GetQuery();
        }

        public int GetCount()
        {
            return this.borrowsRepository.Count();
        }

        private List<string> GetStudentIds()
        {
            var students = this.studentRepository.GetQuery();
            var studentIds = new List<string>();
            foreach (Student item in students)
            {
                studentIds.Add(item.Id);
            }

            return studentIds;
        }

        private List<string> GetBookIds()
        {
            var books = this.bookRepository.GetQuery();
            var bookIds = new List<string>();
            foreach (Book item in books)
            {
                bookIds.Add(item.Id);
            }

            return bookIds;
        }
    }
}
