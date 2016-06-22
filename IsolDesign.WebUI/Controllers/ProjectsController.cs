using IsolDesign.Domain.Handlers;
using IsolDesign.Domain.Interfaces;
using IsolDesign.Domain.Models;
using IsolDesign.WebUI.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace IsolDesign.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
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

        // GET: Projects/Details/5
        public ActionResult Details(int id)
        {
            GetProjects_Handler handler = new GetProjects_Handler();
            var projectModel = handler.GetProjectModel(id);

            ProjectDetailViewModel vm = new ProjectDetailViewModel()
            {
                ProjectModel = projectModel
            };
            return View(vm);
        }

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

            IGetAssignments_Handler assHandler = new GetAssignments_Handler();
            var assignmentModels = assHandler.GetAssignments();
            ViewBag.Assignments = new SelectList(assignmentModels, "AssignmentId", "WorkTitle");

            CreateProjectViewModel vm = new CreateProjectViewModel()
            {
                Project = new ProjectModel(),
                PartnersInfo = partnersInfo,
            };

            return View(vm);
        }

        // POST: Projects/Create
        [HttpPost]
        public ActionResult Create(CreateProjectViewModel model, int assignmentId)
        {
            ProjectModel projectModel = model.Project;
            //projectModel.AssignmentId = assignmentId;

            ICreateProject_Handler handler = new CreateProject_Handler();
            handler.CreateProject(projectModel, assignmentId);
            handler.Execute();

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

        // GET: Projects/Delete/5
        public ActionResult Delete(int id)
        {
            GetProjects_Handler handler = new GetProjects_Handler();
            var projectModel = handler.GetProjectModel(id);

            DeleteProjectViewModel vm = new DeleteProjectViewModel()
            {
                ProjectModel = projectModel
            };
            return View(vm);
        }

        // POST: Projects/Delete/5
        [HttpPost]
        public ActionResult Delete(DeleteProjectViewModel model)
        {
            try
            {
                var id = model.ProjectModel.ProjectId;
                Delete_Handler handler = new Delete_Handler();
                handler.DeleteProjectAndTeams(id);

                return RedirectToAction("Index");
            }
            catch
            {
                GetProjects_Handler handler = new GetProjects_Handler();
                var projectModel = handler.GetProjectModel(model.ProjectModel.ProjectId);

                DeleteProjectViewModel vm = new DeleteProjectViewModel()
                {
                    ProjectModel = projectModel
                };
                return View(vm);
            }
        }
    }
}
