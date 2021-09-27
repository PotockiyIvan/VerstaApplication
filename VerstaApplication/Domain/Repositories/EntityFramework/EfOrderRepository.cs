using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VerstaApplication.Domain.Entities;
using VerstaApplication.Domain.Repositories.Abstract;

namespace VerstaApplication.Domain.Repositories.EntityFramework
{
    public class EFOrderRepository : IOrderRepository
    {
        private readonly AppDbContext context;

        public EFOrderRepository(AppDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Удалить заказ.
        /// </summary>
        /// <param name="id"></param>
        public void DeleteOrder(Guid id)
        {
            context.Orders.Remove(GetOrderById(id));
        }

        /// <summary>
        /// Выбрать заказ по id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Order GetOrderById(Guid id)
        {
            return context.Orders.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Получить все заказы.
        /// </summary>
        /// <returns></returns>
        public IQueryable<Order> GetOrders()
        {
            return context.Orders;
        }

        /// <summary>
        /// Сохранить заказ.
        /// </summary>
        /// <param name="entity"></param>
        public void SaveOrder(Order entity)
        {  

            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
