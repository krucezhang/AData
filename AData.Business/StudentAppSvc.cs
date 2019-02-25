using AData.Business.Interface;
using AData.Persistence.Interface;
using AData.SQLServer.Models;
using System.Collections;
using System.Collections.Generic;

namespace AData.Business
{
    public class StudentAppSvc : IStudentAppSvc
    {
        private IUnitOfWork unitOfWork;
        private IRepository<Student> studentRepository;

        public StudentAppSvc(IUnitOfWork unitOfWork
            , IRepository<Student> userRepository)
        {
            this.unitOfWork = unitOfWork;

            this.studentRepository = userRepository;
            this.studentRepository.UnitOfWork = unitOfWork;
        }

        public void Create(Student student)
        {
            this.unitOfWork.ProcessWithTransaction(() =>
            {
                this.studentRepository.Add(student);
            }
            );
        }

        public IEnumerable<Student> GetAll()
        {
            return this.studentRepository.GetQuery();
        }

        public int GetCount()
        {
            return this.studentRepository.Count();
        }
    }
}
