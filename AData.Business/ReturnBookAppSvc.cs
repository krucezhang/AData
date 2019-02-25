using System.Collections.Generic;
using AData.Business.Interface;
using AData.MySQL;
using AData.Persistence.Interface;

namespace AData.Business
{
    public class ReturnBookAppSvc : IReturnBookAppSvc
    {
        private IUnitOfWork unitOfWork;
        private IRepository<returnbooks> returnbookRepository;

        public ReturnBookAppSvc(IUnitOfWork unitOfWork
            , IRepository<returnbooks> returnbookRepository)
        {
            this.unitOfWork = unitOfWork;

            this.returnbookRepository = returnbookRepository;
            this.returnbookRepository.UnitOfWork = unitOfWork;
        }

        public void Create(returnbooks returnbook)
        {
            this.unitOfWork.ProcessWithTransaction(() =>
            {
                this.returnbookRepository.Add(returnbook);
            }
            );
        }

        public IEnumerable<returnbooks> GetAll()
        {
            return this.returnbookRepository.GetQuery();
        }

        public int GetCount()
        {
            return this.returnbookRepository.Count();
        }
    }
}
