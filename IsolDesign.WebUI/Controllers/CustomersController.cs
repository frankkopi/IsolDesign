using System.Web.Mvc;
using IsolDesign.Domain.Handlers;
using IsolDesign.WebUI.Models;
using IsolDesign.Domain.Models;

namespace IsolDesign.WebUI.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            GetCustomers_Handler handler = new GetCustomers_Handler();
            var customerModels = handler.GetAllCustomers();

            CustomersIndexViewModel vm = new CustomersIndexViewModel()
            {
                CustomerModels = customerModels
            };   
            return View(vm);
        }

        //// GET: Customers/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Customers/Create
        [HttpGet]
        public ActionResult Create()
        {
            CustomerModel customerModel = new CustomerModel();
            CreateCustomerViewModel vm = new CreateCustomerViewModel
            {
                CustomerModel = customerModel
            };
                
            return View(vm);
        }

        // POST: Customers/Create
        [HttpPost]
        public ActionResult Create(CreateCustomerViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var customerModel = vm.CustomerModel;
                CreateCustomer_Handler handler = new CreateCustomer_Handler();
                handler.CreateCustomer(customerModel);
            }
            return RedirectToAction("Index");
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            GetCustomers_Handler handler = new GetCustomers_Handler();
            var customerModel = handler.GetCustomerModel(id);

            EditCustomerViewModel vm = new EditCustomerViewModel
            {
                CustomerModel = customerModel
            };

            return View(vm);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        public ActionResult Edit(EditCustomerViewModel vm, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                EditCustomer_Handler handler = new EditCustomer_Handler();
                handler.EditCustomer(vm.CustomerModel);
            }

           return RedirectToAction("Index");
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            GetCustomers_Handler handler = new GetCustomers_Handler();
            var customerModel = handler.GetCustomerModel(id);
            return View(customerModel);
        }

        // POST: Customers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                DeleteCustomer_Handler handler = new DeleteCustomer_Handler();
                handler.DeleteCustomer(id);
            }

            return RedirectToAction("Index");
        }
    }
}
