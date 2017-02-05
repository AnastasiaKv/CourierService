using DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UOW
{
    public interface IUnitOfWork
    {
        #region IRepository properties
        IUserRepository UserRepository { get; }
        IOrderRepository OrderRepository { get; }
        IOrderItemRepository OrderItemRepository { get; }
        IUserRoleRepository UserRoleRepository { get; }
        ILuggageTypeRepository LuggageTypeRepository { get; }
        ICourierTransportTypeRepository CourierTransportTypeRepository { get; }
        IStatusRepository StatusRepository { get; }

        #endregion

        #region IRepository methods
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, new();

        #endregion
    }
}
