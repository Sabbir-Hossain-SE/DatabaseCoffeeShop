using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MyWindowsFormsApp.Repository;
namespace MyWindowsFormsApp.Manager
{
    class CustomerManager
    {
        CustomerRepository _customerRepository = new CustomerRepository();

        public bool Add(string name, string address, string phone)
        {
            return _customerRepository.Add(name, address, phone );
        }
        public bool IsNameExist(string name)
        {
            return _customerRepository.IsNameExist(name);
        }

        public bool Delete(int id)
        {
            return _customerRepository.Delete(id);
        }
        public bool Update(string name, string address, string phone, int id)
        {
            return _customerRepository.Update(name, address, phone, id);
        }
        public DataTable Display()
        {
            return _customerRepository.Display();
        }

        public DataTable Search(string name)
        {
            return _customerRepository.Search(name);
        }

    }
}
