using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VerstaApplication.Domain.Repositories.Abstract;


namespace VerstaApplication.Domain.Repositories
{
    /*Класс помошник,который будет точкой входа для DataBase контекста
     * нужен для удобства управления сущностями из репозитория и всеми операциями над ними
     * вместо того ,чтобы по отдельности вызывать репозитории,можно будет передавать 
     * экземпляр этого класса и у него вызывать нужные свойства
    */
    public class DataManager
    {

        public IOrderRepository Orders { get; set; }


        public DataManager(IOrderRepository orderRepository)
        {
            Orders = orderRepository;
        }
    }
}
