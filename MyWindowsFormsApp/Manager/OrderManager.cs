using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MyWindowsFormsApp.Repository;
namespace MyWindowsFormsApp.Manager
{
    class OrderManager
    {
        OrderRepository _orderRepository = new OrderRepository();

        public bool Add(int quantity, double totalPrice, int itemId, int customerId)
        {
            return _orderRepository.Add(quantity, totalPrice, itemId, customerId);
        }
   

        public bool Delete(int id)
        {
            return _orderRepository.Delete(id);
        }
        public bool Update(int quantity, double totalPrice, int itemId, int customerId, int id)
        {
            return _orderRepository.Update(quantity, totalPrice, itemId, customerId, id);
        }
        public DataTable Display()
        {
            return _orderRepository.Display();
        }

        public DataTable Search(int cutomerId)
        {
            return _orderRepository.Search(cutomerId);
        }

    }
}
