using DAL.IRepositories;
using DBModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class OrderItemRepository: GenericRepository<OrderItem>, IOrderItemRepository
    {
    }
}
