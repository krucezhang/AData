using AData.Business.Interface;
using AData.MySQL;
using AData.Persistence.Interface;
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

        public BorrowAppSvc(IUnitOfWork unitOfWork
            , IRepository<borrows> borrowsRepository)
        {
            this.unitOfWork = unitOfWork;

            this.borrowsRepository = borrowsRepository;
            this.borrowsRepository.UnitOfWork = unitOfWork;
        }

        public void Create(borrows borrow)
        {
            this.unitOfWork.ProcessWithTransaction(() =>
            {
                this.borrowsRepository.Add(borrow);
            }
            );
        }

        public IEnumerable<borrows> GetAll()
        {
            return this.borrowsRepository.GetQuery();
        }

        public int GetCount()
        {
            return this.borrowsRepository.Count();
        }
    }
}
