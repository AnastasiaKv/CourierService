using DAL.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Manager
{
    public class DBManager
    {
        private static IUnitOfWork _unitOfWork;
        public static IUnitOfWork UnitOfWork
        {
            get
            {
                return _unitOfWork ?? (_unitOfWork = new UnitOfWork());
            }
        }
    }
}
