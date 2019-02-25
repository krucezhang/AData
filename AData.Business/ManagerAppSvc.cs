using AData.Business.Interface;
using AData.MongoDB.Models;
using AData.Persistence.Interface;

namespace AData.Business
{
    public class ManagerAppSvc : IManagersAppSvc
    {
        private IMongonDBRepository<Managers> managerRespository;

        public ManagerAppSvc(IMongonDBRepository<Managers> managerRespository)
        {
            this.managerRespository = managerRespository;
        }

        public void Create(Managers manager)
        {
            this.managerRespository.Save(manager);
        }

        public int GetCount()
        {
            return this.managerRespository.Count();
        }
    }
}
