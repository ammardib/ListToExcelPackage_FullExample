using ExamplesListToExcelPackage.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamplesListToExcelPackage.API.Infrastructure.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {

        /// <summary>
        /// Generates random list of orders, 
        /// Should be replaced by method to get data from persistent store
        /// </summary>
        /// <returns></returns>
        public List<Order> GetOrders()
        {
            Random _random = new Random();
        
            var list = new List<Order>();
            for (int i=1; i<=1000; i++)
            {
                var id = _random.Next(1, 99999).ToString();
                list.Add(new Order()
                {
                    OrderId = int.Parse("800" + id.PadLeft(5, '0')),
                    OrderAmount = _random.Next(100, 999),
                    OrderDate = DateTime.Now.AddDays(-_random.Next(1,30))
                });
            }
            return list;
        }
    }
}
