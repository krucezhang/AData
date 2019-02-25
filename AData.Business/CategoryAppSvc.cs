using AData.Business.Interface;
using AData.MongoDB.Models;
using AData.Persistence.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AData.Business
{
    public class CategoryAppSvc: ICategoryAppSvc
    {
        private IMongonDBRepository<Category> categoryRespository;

        public CategoryAppSvc(IMongonDBRepository<Category> categoryRespository)
        {
            this.categoryRespository = categoryRespository;
        }

        public void Create(Category category)
        {
            this.categoryRespository.Save(category);
        }

        public IEnumerable<Category> GetAll()
        {
            return this.categoryRespository.GetAll();
        }

        public int GetCount()
        {
            return this.categoryRespository.Count();
        }
    }
}
