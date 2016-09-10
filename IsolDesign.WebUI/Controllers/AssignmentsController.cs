﻿using IsolDesign.Domain.Handlers;
using IsolDesign.Domain.Interfaces;
using IsolDesign.Domain.Models;
using IsolDesign.WebUI.Models;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System;

namespace IsolDesign.WebUI.Controllers
{
    [Authorize(Roles = "Admin, User")]
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
                string userName = User.Identity.GetUserName(); // gets the userName from logged in User. userName is the email.
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

            OrderedAssignmentModel assignmentModel = new OrderedAssignmentModel();
            assignmentModel.Deadline = DateTime.Today;

            CreateOrderedAssignmentViewModel vm = new CreateOrderedAssignmentViewModel()
            {
                orderedAssignmentModel = assignmentModel
            };
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

        // GET: Assignments/Delete/5
        public ActionResult Delete(int id)
        {
            GetAssignments_Handler handler = new GetAssignments_Handler();
            AssignmentModel assignmentModel = handler.GetAssignment(id);
            return View(assignmentModel);
        }

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
