﻿using IsolDesign.Domain.Handlers;
using IsolDesign.Domain.Interfaces;
using IsolDesign.Domain.Models;
using IsolDesign.WebUI.Models;
using System.Web.Mvc;

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

        // GET: Assignments/Create
        public ActionResult Create()
        {
            CreateAssignmentViewModel vm = new CreateAssignmentViewModel();
            return View(vm);
        }

        // POST: Assignments/Create
        [HttpPost]
        public ActionResult Create(CreateAssignmentViewModel vm)
        {
            if (ModelState.IsValid)
            {

            }
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
