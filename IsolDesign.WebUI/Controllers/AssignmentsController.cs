using IsolDesign.Domain.Handlers;
using IsolDesign.Domain.Interfaces;
using IsolDesign.Domain.Models;
using IsolDesign.WebUI.Models;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace IsolDesign.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AssignmentsController : Controller
    {
        // GET: Assignments
        public ActionResult Index()

        {
            IGetAssignments_Handler handler = new GetAssignments_Handler();
            var assignments = handler.GetAssignments();

            AssignmentsIndexViewModel vm = new AssignmentsIndexViewModel()
            {
                Assignment = new AssignmentModel(),
                Assignments = assignments
            };
            return View(vm);
        }

        //// GET: Assignments/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}


        [HttpGet]
        public ActionResult CreatePartnerAssignment()
        {
            IGetCustomers_Handler handler = new GetCustomers_Handler();
            var customerModels = handler.GetAllCustomers();

            CreatePartnerAssignmentViewModel vm = new CreatePartnerAssignmentViewModel();
            return View(vm);
        }

        [HttpPost]
        public ActionResult CreatePartnerAssignment(CreatePartnerAssignmentViewModel vm)
        {

            if (ModelState.IsValid)
            {
                string userName = User.Identity.GetUserName();
                var images = Request.Files;
                var assignmentModel = vm.partnerAssignmentModel;

                ICreateAssignment_Handler handler = new CreateAssignment_Handler(images);
                handler.CreatePartnerAssignment(assignmentModel, userName);
            }

            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult CreateOrderedAssignment()
        {
            IGetCustomers_Handler handler = new GetCustomers_Handler();
            var customerModels = handler.GetAllCustomers();
            ViewBag.Customers = new SelectList(customerModels, "CustomerId", "Name");

            CreateOrderedAssignmentViewModel vm = new CreateOrderedAssignmentViewModel();
            return View(vm);
        }

        [HttpPost]
        public ActionResult CreateOrderedAssignment(CreateOrderedAssignmentViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var images = Request.Files;
                var assignmentModel = vm.orderedAssignmentModel;

                ICreateAssignment_Handler handler = new CreateAssignment_Handler(images);
                handler.CreateOrderedAssignment(assignmentModel);
            }

            return RedirectToAction("Index");
        }



        //// GET: Assignments/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Assignments/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Assignments/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Assignments/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
