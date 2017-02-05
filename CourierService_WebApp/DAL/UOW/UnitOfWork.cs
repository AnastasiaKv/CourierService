using DAL.IRepositories;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        #region private fields

        private IUserRepository _userRepository;
        private IOrderRepository _orderRepository;
        private IOrderItemRepository _orderItemRepository;
        private IUserRoleRepository _userRoleRepository;
        private ILuggageTypeRepository _luggageTypeRepository;
        private ICourierTransportTypeRepository _courierTransportTypeRepository;
        private IStatusRepository _statusRepository;

        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();
        #endregion

        #region public properties
        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository();
                }
                return _userRepository;
            }
        }
        public IOrderRepository OrderRepository
        {
            get
            {
                if (_orderRepository == null)
                {
                    _orderRepository = new OrderRepository();
                }
                return _orderRepository;
            }
        }
        public IOrderItemRepository OrderItemRepository
        {
            get
            {
                if (_orderItemRepository == null)
                {
                    _orderItemRepository = new OrderItemRepository();
                }
                return _orderItemRepository;
            }
        }
        public IUserRoleRepository UserRoleRepository
        {
            get
            {
                if (_userRoleRepository == null)
                {
                    _userRoleRepository = new UserRoleRepository();
                }
                return _userRoleRepository;
            }
        }
        public ILuggageTypeRepository LuggageTypeRepository
        {
            get
            {
                if (_luggageTypeRepository == null)
                {
                    _luggageTypeRepository = new LuggageTypeRepository();
                }
                return _luggageTypeRepository;
            }
        }
        public ICourierTransportTypeRepository CourierTransportTypeRepository
        {
            get
            {
                if (_courierTransportTypeRepository == null)
                {
                    _courierTransportTypeRepository = new CourierTransportTypeRepository();
                }
                return _courierTransportTypeRepository;
            }
        }
        public IStatusRepository StatusRepository
        {
            get
            {
                if (_statusRepository == null)
                {
                    _statusRepository = new StatusRepository();
                }
                return _statusRepository;
            }
        }

        #endregion

        #region public methods
        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, new()
        {
            // Checks if the Dictionary Key contains the Model class
            if (_repositories.Keys.ToList().Contains(typeof(TEntity)))
            {
                // Return the repository for that Model class
                return _repositories[typeof(TEntity)] as IRepository<TEntity>;
            }

            // If the repository for that Model class doesn't exist, create it
            var repository = new GenericRepository<TEntity>();

            // Add it to the dictionary
            _repositories.Add(typeof(TEntity), repository);

            return repository;
        }
        #endregion
    }
}
