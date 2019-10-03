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

        public bool Add(int quantity,double totalPrice, string custName, string itemName)
        {
            return _orderRepository.Add(quantity, totalPrice,custName,itemName);
        }
        public bool IsNameExist(string custName)
        {
            return _orderRepository.IsNameExist(custName);
        }

        public bool Delete(int id)
        {
            return _orderRepository.Delete(id);
        }
        public bool Update(int quantity, double totalPrice, string custName, string itemName, int id)
        {
            return _orderRepository.Update(quantity, totalPrice, custName, itemName, id);
        }
        public DataTable Display()
        {
            return _orderRepository.Display();
        }

        public DataTable Search(string custName)
        {
            return _orderRepository.Search(custName);
        }

    }
}
