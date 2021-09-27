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
        /// Выбрать заказ по id.
        /// </summary>
        /// <param name="id">Первичный ключ.</param>
        /// <returns></returns>
        Order GetOrderById(Guid id);

        /// <summary>
        /// Сохранить заказ.
        /// </summary>
        /// <param name="entity"></param>
        void SaveOrder(Order entity);

        /// <summary>
        /// Удалить заказ.
        /// </summary>
        /// <param name="id">Первичный ключ.</param>
        void DeleteOrder(Guid id);
    }
}
