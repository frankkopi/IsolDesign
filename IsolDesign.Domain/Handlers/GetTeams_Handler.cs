using IsolDesign.DataAccess;
using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess.Interfaces.IUnitOfWork;
using IsolDesign.Domain.Interfaces;
using IsolDesign.Domain.Models;
using System.Collections.Generic;
using IsolDesign.Domain.Helpers;

namespace IsolDesign.Domain.Handlers
{
    public class GetTeams_Handler :IGetTeams_Handler
    {
        private ApplicationDbContext _context;
        private IUnitOfWork _unitOfWork;

        public GetTeams_Handler()
        {
            this._context = new ApplicationDbContext();
            this._unitOfWork = new UnitOfWork(_context);
        }

        public IEnumerable<TeamModel> GetTeams()
        {
            var teamsFromDb = _unitOfWork.Teams.GetAll();
            List<TeamModel> teamModels = new List<TeamModel>();

            foreach (var team in teamsFromDb)
            {
                TeamModel teamModel = new TeamModel
                {
                    TeamId = team.TeamId,
                    Name = team.Name,
                    ProjectId = team.ProjectId,
                    Project = null,
                    Partners = null
                };

                // Converting team.Project to ProjectModel
                ProjectModel projectModel = ProjectConverter.ConvertToProjectModel(team.Project);

                // converting Partner to PartnerModel for projectModel.ProjectLeader
                if (team.Project.ProjectLeader != null)
                {
                    PartnerModel projectLeader = PartnerConverter.ConvertToPartnerModel(team.Project.ProjectLeader);

                    // convert List<PortfolioSubject> to List<PortfolioSubjectModel> for project leaders portfolio
                    List<PortfolioSubjectModel> portfolio = PortfolioConverter.ConvertToPortfolioSubjectModels(team.Project.ProjectLeader.Portfolio);
                    projectLeader.Portfolio = portfolio;

                    // convert List<Competency> to List<CompetencyModel> for project leaders competencies
                    var competencyModels = CompetencyConverter.ConvertToCompetencyModels(team.Project.ProjectLeader.Competencies);
                    projectLeader.Competencies = competencyModels;
                    projectModel.ProjectLeader = projectLeader;
                }


                List<TeamModel> teams = new List<TeamModel>();
                foreach (var teamInProject in team.Project.Teams)
                {
                    TeamModel newTeamModel = new TeamModel()
                    {
                        TeamId = teamInProject.TeamId,
                        Name = teamInProject.Name,
                        ProjectId = teamInProject.ProjectId,
                        Project = null,
                        Partners = null
                    };
                    teams.Add(newTeamModel);
                }
                projectModel.Teams = teams;
                teamModel.Project = projectModel;


                // convert List<Partner> to List<PartnerModel> for teamModel.Partners
                List<PartnerModel> partnerModels = new List<PartnerModel>();
                foreach (var partner in team.Partners)
                {
                    PartnerModel partnerModel = PartnerConverter.ConvertToPartnerModel(partner);

                    // convert List<PortfolioSubject> to List<PortfolioSubjectModel>
                    List<PortfolioSubjectModel> portfolioSubjects = PortfolioConverter.ConvertToPortfolioSubjectModels(partner.Portfolio);
                    partnerModel.Portfolio = portfolioSubjects;

                    // convert List<Competency> to List<CompetencyModel>
                    List<CompetencyModel> partnerCompetencyModels = CompetencyConverter.ConvertToCompetencyModels(partner.Competencies);
                    partnerModel.Competencies = partnerCompetencyModels;
                }

            teamModels.Add(teamModel);
            }

            return teamModels;
        }

        public TeamModel GetTeam(int teamId)
        {
            var team = _unitOfWork.Teams.Get(teamId);
            var teamModel = TeamConverter.ConvertToTeamModel(team);

            return teamModel;
        }
    }
}






