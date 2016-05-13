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
    public class TeamsController : Controller
    {
        // GET: Teams
        public ActionResult Index()
        {
            IGetTeams_Handler handler = new GetTeams_Handler();
            var teamModels = handler.GetTeams();

            TeamsIndexViewModel vm = new TeamsIndexViewModel
            {
                Teams = teamModels,
                Team = new TeamModel(),
                Project = new ProjectModel()

            };
            return View(vm);
        }

        //// GET: Teams/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Teams/Create
        public ActionResult Create()
        {
            TeamModel teamModel = new TeamModel();
            PartnerModel partnerModel = new PartnerModel();

            ICreateTeam_Handler handler = new CreateTeam_Handler();
            var partnerModels = handler.GetPartners();
            var projectModels = handler.GetProjects();

            CreateTeamViewModel vm = new CreateTeamViewModel()
            {
                Team = teamModel,
                Partner = partnerModel,
                Partners = partnerModels,
                Projects = projectModels
            };

            return View(vm);
        }

        // POST: Teams/Create
        [HttpPost]
        //public ActionResult Create(FormCollection collection)
        public ActionResult Create(CreateTeamViewModel model, IEnumerable<int> partnerIds)
        {
            if (ModelState.IsValid)
            {
                ICreateTeam_Handler handler = new CreateTeam_Handler();
                handler.CreateTeam(model.Team, partnerIds);
                handler.Execute();

                return RedirectToAction("Index");
            }
           
             return View();
            
        }

        //// GET: Teams/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Teams/Edit/5
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

        //// GET: Teams/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Teams/Delete/5
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
