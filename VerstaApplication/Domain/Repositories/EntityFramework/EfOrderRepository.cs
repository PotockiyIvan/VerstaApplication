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
            {
                int orderNumber;

                if (context.Orders.Any())
                    orderNumber = GetOrders().OrderBy(x => x.OrderNumber).Last().OrderNumber;
                else
                    orderNumber = 0;
                
                entity.OrderNumber = orderNumber == 0 ? 1 :++orderNumber;
                context.Entry(entity).State = EntityState.Added;
            }
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
