using IsolDesign.Domain.Handlers;
using IsolDesign.Domain.Interfaces;
using IsolDesign.Domain.Models;
using IsolDesign.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IsolDesign.WebUI.Controllers
{
    public class ProjectsController : Controller
    {
        // GET: Projects
        public ActionResult Index()
        {
            IGetProjects_Handler handler = new GetProjects_Handler();
            var projectModels = handler.GetProjects();

            ProjectsIndexViewModel vm = new ProjectsIndexViewModel
            {
                Project = new ProjectModel(),
                Projects = projectModels
            };

            return View(vm);
        }

        //// GET: Projects/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Projects/Create
        public ActionResult Create()
        {
            GetPartners_Handler handler = new GetPartners_Handler();
            var partnerModels = handler.GetPartners();

            List<object> partnersInfo = new List<object>();
            foreach (var p in partnerModels)
            {
                partnersInfo.Add(new {
                    PartnerId = p.PartnerId,
                    Info = p.Name + ", " + p.City + ", " + p.Country + ", " + p.Email
                });
            }

            CreateProjectViewModel vm = new CreateProjectViewModel()
            {
                Project = new ProjectModel(),
                PartnersInfo = partnersInfo
            };

            return View(vm);
        }

        // POST: Projects/Create
        [HttpPost]
        public ActionResult Create(CreateProjectViewModel model)
        {
            ProjectModel projectModel = model.Project;
            ICreateProject_Handler handler = new CreateProject_Handler();
            handler.CreateProject(projectModel);

            return RedirectToAction("Index");
        }

        //// GET: Projects/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Projects/Edit/5
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

        //// GET: Projects/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Projects/Delete/5
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
