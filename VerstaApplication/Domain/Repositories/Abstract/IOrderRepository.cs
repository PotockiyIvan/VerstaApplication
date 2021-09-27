using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VerstaApplication.Domain.Entities;

namespace VerstaApplication.Domain.Repositories.Abstract
{
    public interface IOrderRepository
    {
        /// <summary>
        /// Получить все заказы.
        /// </summary>
        /// <returns></returns>
        IQueryable<Order> GetOrders();

        /// <summary>
        /// Сохранить заказ.
        /// </summary>
        /// <param name="entity"></param>
        void SaveOrder(Order entity);

    }
}
