using AData.Business.Interface;
using AData.MongoDB.Models;
using AData.Persistence.Interface;

namespace AData.Business
{
    public class TicketsAppSvc : ITicketsAppSvc
    {
        private IMongonDBRepository<Tickets> ticketsRespository;

        public TicketsAppSvc(IMongonDBRepository<Tickets> ticketsRespository)
        {
            this.ticketsRespository = ticketsRespository;
        }

        public void Create(Tickets ticket)
        {
            this.ticketsRespository.Save(ticket);
        }

        public int GetCount()
        {
            return this.ticketsRespository.Count();
        }
    }
}
