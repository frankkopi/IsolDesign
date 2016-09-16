using IsolDesign.Data.Models;
using IsolDesign.Domain.Models;

namespace IsolDesign.Domain.Helpers
{
    public class CustomerConverter
    {
        public static CustomerModel ConvertToCustomerModel(Customer customer)
        {
            CustomerModel customerModel = new CustomerModel
            {
                CustomerId = customer.CustomerId,
                Name = customer.Name,
                Address = customer.Address,
                Country = customer.Country,
                Phone = customer.Phone,
                Email = customer.Email,
                Category = customer.Category,
                Homepage = customer.Homepage,
                ContactName = customer.ContactName,
                ContactPhone = customer.ContactPhone,
                ContactEmail = customer.ContactEmail
            };

            return customerModel;
        } 
    }
}
