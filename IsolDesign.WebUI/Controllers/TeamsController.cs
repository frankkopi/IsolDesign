using IsolDesign.Domain.Handlers;
using IsolDesign.Domain.Helpers;
using IsolDesign.Domain.Interfaces;
using IsolDesign.Domain.Models;
using IsolDesign.WebUI.Models;
using System.Web.Mvc;

namespace IsolDesign.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
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

        // GET: Teams/Details/5
        public ActionResult Details(int id)
        {
            GetTeams_Handler handler = new GetTeams_Handler();
            var teamModel = handler.GetTeam(id);

            return View(teamModel);
        }

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
                PartnerModel = partnerModel,
                Partners = partnerModels,
                Projects = projectModels
            };

            var list = Dropdownlist_Helper.PopulateProjectsList(projectModels);
            ViewBag.ProjectList = new SelectList(list, "ProjectId", "ProjectLeader");

            return View(vm);
        }

        // POST: Teams/Create
        [HttpPost]
        //public ActionResult Create(FormCollection collection)
        public ActionResult Create(CreateTeamViewModel model, string partnerIds, int projectId, int? projectLeaderId)
        {
            if (ModelState.IsValid)
            {
                ICreateTeam_Handler handler = new CreateTeam_Handler();
                handler.CreateTeam(model.Team, partnerIds, projectId);
                handler.Execute(projectLeaderId);

                return RedirectToAction("Index");
            }
             return View();
        }

        // GET: Teams/Edit/5
        public ActionResult Edit(int id)
        {
            GetTeams_Handler handler = new GetTeams_Handler();
            var teamModel = handler.GetTeam(id);

            GetProjects_Handler handler2 = new GetProjects_Handler();
            var projectModels = handler2.GetProjects();

            var list = Dropdownlist_Helper.PopulateProjectsList(projectModels);

            var partnerModel = new PartnerModel();

            GetPartners_Handler handler3 = new GetPartners_Handler();
            var partnerModels = handler3.GetPartners();

            EditTeamViewModel vm = new EditTeamViewModel()
            {
                Team = teamModel,
                ProjectsSelectList = new SelectList(list, "ProjectId", "ProjectLeader", teamModel.ProjectId),
                PartnerModel = partnerModel,
                Partners = partnerModels,
                Projects = projectModels
            };

            return View(vm);
        }

        // POST: Teams/Edit/5
        [HttpPost]
        public ActionResult Edit(EditTeamViewModel model, string partnerIds, int projectId, int? projectLeaderId)
        {
            try
            {
                IEditTeam_Handler handler = new EditTeam_Handler();
                handler.EditTeam(model.Team, partnerIds, projectId, projectLeaderId);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Teams/Delete/5
        public ActionResult Delete(int id)
        {
            GetTeams_Handler handler = new GetTeams_Handler();
            var teamModel = handler.GetTeam(id);

            DeleteTeamViewModel vm = new DeleteTeamViewModel()
            {
                Team = teamModel
            };
            return View(vm);
        }

        // POST: Teams/Delete/5
        [HttpPost]
        //public ActionResult Delete(int id, string Name, FormCollection collection)
        public ActionResult Delete(DeleteTeamViewModel model)
        {
            var teamId = model.Team.TeamId;
            var teamName = model.Team.Name;
            ViewBag.TeamName = teamName;
            try
            {
                Delete_Handler handler = new Delete_Handler();
                handler.DeleteTeam(teamId);

                return View("ConfirmTeamDeleted");
            }
            catch
            {
                GetTeams_Handler handler = new GetTeams_Handler();
                var teamModel = handler.GetTeam(teamId);
                DeleteTeamViewModel vm = new DeleteTeamViewModel()
                {
                    Team = teamModel
                };
                return View(vm);
            }
        }
    }
}
