using AData.Persistence.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AData.Business
{
    internal static class Extensions
    {
        public static void ProcessWithTransaction(this IUnitOfWork unitOfWork, Action action)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unitOfWork");
            }

            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            bool needRollback = false;

            try
            {
                unitOfWork.BeginTransaction();
                needRollback = true;
                action();
                unitOfWork.CommitTransaction();
                needRollback = false;
            }
            catch
            {
                if (needRollback)
                {
                    unitOfWork.RollBackTransaction();
                }

                throw;
            }
        }
    }
}
