using ExamplesListToExcelPackage.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamplesListToExcelPackage.API.Infrastructure.Repositories
{
    public interface IOrdersRepository
    {
        public List<Order> GetOrders();
    }
}
