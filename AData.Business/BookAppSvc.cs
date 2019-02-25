using AData.Business.Interface;
using AData.Persistence.Interface;
using AData.SQLServer.Models;
using System.Collections.Generic;

namespace AData.Business
{
    public class BookAppSvc : IBookAppSvc
    {
        private IUnitOfWork unitOfWork;
        private IRepository<Book> bookRepository;

        public BookAppSvc(IUnitOfWork unitOfWork
            , IRepository<Book> bookRepository)
        {
            this.unitOfWork = unitOfWork;

            this.bookRepository = bookRepository;
            this.bookRepository.UnitOfWork = unitOfWork;
        }

        public void Create(Book book)
        {
            this.unitOfWork.ProcessWithTransaction(() =>
            {
                this.bookRepository.Add(book);
            }
            );
        }

        public IEnumerable<Book> GetAll()
        {
            return this.bookRepository.GetQuery();
        }

        public int GetCount()
        {
            return this.bookRepository.Count();
        }
    }
}
