using ExamplesListToExcelPackage.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamplesListToExcelPackage.API.Infrastructure.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        //Should be replaced by method to get data from persistent store
        public List<Order> GetOrders()
        {
            return new List<Order>() {
            new Order(){OrderId = 80000012, OrderAmount = 540.5M, OrderDate=DateTime.Now.AddDays(-20)},
            new Order(){OrderId = 80000710, OrderAmount = 140, OrderDate=DateTime.Now.AddDays(-5)},
            new Order(){OrderId = 80000654, OrderAmount = 90.85M, OrderDate=DateTime.Now.AddDays(-15)},
            new Order(){OrderId = 80000223, OrderAmount = 1100.6M, OrderDate=DateTime.Now.AddDays(-2)},
            new Order(){OrderId = 80000845, OrderAmount = 85M, OrderDate=DateTime.Now.AddDays(-10)},
            new Order(){OrderId = 80000631, OrderAmount = 302.25M, OrderDate=DateTime.Now.AddDays(-8)},
            new Order(){OrderId = 80000524, OrderAmount = 145M, OrderDate=DateTime.Now.AddDays(-2)},
            };

        }
    }
}
