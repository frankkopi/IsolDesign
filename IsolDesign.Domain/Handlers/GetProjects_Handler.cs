using IsolDesign.Domain.Interfaces;
using System.Collections.Generic;
using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess.Interfaces.IUnitOfWork;
using IsolDesign.DataAccess;
using IsolDesign.Domain.Models;
using IsolDesign.Domain.Helpers;
using IsolDesign.Data.Models;

namespace IsolDesign.Domain.Handlers
{
    public class GetProjects_Handler : IGetProjects_Handler
    {
        private ApplicationDbContext _context;
        private IUnitOfWork _unitOfWork;

        public GetProjects_Handler()
        {
            this._context = new ApplicationDbContext();
            this._unitOfWork = new UnitOfWork(_context);
        }

        public IEnumerable<ProjectModel> GetProjects()
        {
            var allProjects = GetAllProjects(_unitOfWork);
            return allProjects;
        }

        public IEnumerable<ProjectModel> GetAllProjects(IUnitOfWork unitOfWork)
        {
            var projectsFromDb = unitOfWork.Projects.GetAll();
            List<ProjectModel> projectModels = new List<ProjectModel>();

            foreach (var project in projectsFromDb)
            {
                ProjectModel projectModel = ProjectConverter.ConvertToProjectModel(project);

                if (project.PartnerId != null)
                {
                    // convert Partner to PartnerModel (the project leader)
                    PartnerModel projectLeader = PartnerConverter.ConvertToPartnerModel2(project.ProjectLeader);
                    projectModel.ProjectLeader = projectLeader;
                }

                // converting List<Team> to List<TeamModel>
                List<TeamModel> teamModels = new List<TeamModel>();
                foreach (var team in project.Teams)
                {
                    var TeamModel = new TeamModel
                    {
                        TeamId = team.TeamId,
                        Name = team.Name,
                        ProjectId = team.ProjectId
                    };
                    teamModels.Add(TeamModel);
                }

                projectModel.Teams = teamModels;
                projectModels.Add(projectModel);
            }

            return projectModels;
        }

        public Project GetProject(int projectId)
        {
            var project = _unitOfWork.Projects.Get(projectId);
            _unitOfWork.Dispose(); // Dispose context because of: Entity Framework An entity object cannot be referenced by multiple instances of IEntityChangeTracker
            return project;
        }
    }
}







//public IEnumerable<ProjectModel> GetProjects()
//{
//    var projectsFromDb = _unitOfWork.Projects.GetAll();
//    List<ProjectModel> projectModels = new List<ProjectModel>();

//    foreach (var project in projectsFromDb)
//    {
//        ProjectModel projectModel = new ProjectModel()
//        {
//            ProjectId = project.ProjectId,
//            Name = project.Name,
//            StartDate = project.StartDate,
//            Deadline = project.Deadline,
//            PartnerId = project.PartnerId, // a partner is chosen as a project leader
//            Teams = null,
//            ProjectLeader = null
//        };

//        if (project.PartnerId != null)
//        {
//            // converting Partner to PartnerModel (the project leader)
//            PartnerModel projectLeader = new PartnerModel
//            {
//                PartnerId = project.ProjectLeader.PartnerId,
//                Name = project.ProjectLeader.Name,
//                Address = project.ProjectLeader.Address,
//                City = project.ProjectLeader.City,
//                Country = project.ProjectLeader.Country,
//                Phone = project.ProjectLeader.Phone,
//                Email = project.ProjectLeader.Email,
//                ProfileImagePath = project.ProjectLeader.ProfileImagePath,
//                Description = null,
//                SkypeLink = null,
//                Facebook = null,
//                LinkedIn = null,
//                Homepage = null,
//                TeamId = null,
//                Competencies = null,
//                Portfolio = null,
//                Subcontractors = null,
//                Assignments = null
//            };
//            projectModel.ProjectLeader = projectLeader;
//        }

//        // converting List<Team> to List<TeamModel>
//        List<TeamModel> teamModels = new List<TeamModel>();
//        foreach (var team in project.Teams)
//        {
//            var TeamModel = new TeamModel
//            {
//                TeamId = team.TeamId,
//                Name = team.Name,
//                ProjectId = team.ProjectId
//            };
//            teamModels.Add(TeamModel);
//        }

//        projectModel.Teams = teamModels;
//        projectModels.Add(projectModel);
//    }

//    return projectModels;
//}
