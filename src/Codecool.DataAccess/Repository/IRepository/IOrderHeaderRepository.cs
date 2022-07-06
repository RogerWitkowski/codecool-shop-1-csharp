using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codecool.Models;

namespace Codecool.DataAccess.Repository.IRepository
{
    public interface IOrderHeaderRepository : IRepository<OrderHeader>
    {
        void Update(OrderHeader objOrderHeader);
        void UpdateStatus(int id, string orderStatus, string? paymentStatus=null);
    }
}
