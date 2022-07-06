using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codecool.DataAccess.Repository.IRepository;
using Codecool.Models;

namespace Codecool.DataAccess.Repository
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {

        private ApplicationDbContext _db;

        public OrderDetailRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(OrderDetail objOrderDetail)
        {
            _db.OrderDetails.Update(objOrderDetail);
        }
    }
}

