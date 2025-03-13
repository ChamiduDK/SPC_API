using SPC_API.Model;
using SPC_API.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace SPC_API.Data
{
    public class OrderRepo
    {
        private readonly AppDBContext _dbContext;

        public OrderRepo(AppDBContext context)
        {
            _dbContext = context;
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() > 0;
        }

        public bool CreateOrder(Order order)
        {
            try
            {
                _dbContext.Orders.Add(order);
                return Save();
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public bool UpdateOrder(Order order)
        {
            if (order != null)
            {
                _dbContext.Orders.Update(order);
                return Save();
            }
            return false;
        }

        public bool DeleteOrder(Order order)
        {
            if (order != null)
            {
                _dbContext.Orders.Remove(order);
                return Save();
            }
            return false;
        }

        public Order GetOrderById(int id)
        {
            return _dbContext.Orders.FirstOrDefault(o => o.OrderId == id);
        }

        public IEnumerable<Order> GetOrders()
        {
            return _dbContext.Orders.ToList();
        }

        public IEnumerable<Order> GetOrdersByPharmacy(string pharmacyId)
        {
            return _dbContext.Orders.Where(o => o.PharmacyId == pharmacyId).ToList();
        }
    }
}
