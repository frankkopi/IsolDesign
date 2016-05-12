using IsolDesign.DataAccess;
using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess.Interfaces.IUnitOfWork;
using IsolDesign.Domain.Interfaces;
using IsolDesign.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                // Converting Project to ProjectModel
                ProjectModel projectModel = new ProjectModel
                {
                    ProjectId = team.Project.ProjectId,
                    Name = team.Project.Name,
                    StartDate = team.Project.StartDate,
                    Deadline = team.Project.Deadline,
                    PartnerId = team.Project.PartnerId,
                    DevMethodId = team.Project.DevMethodId,
                    EconomyId = team.Project.EconomyId,
                    AssignmentId = team.Project.AssignmentId,
                    ProjectLeader = null,
                    Teams = null
                };

                // converting Partner to PartnerModel for project leader
                PartnerModel projectLeader = new PartnerModel
                {
                    PartnerId = team.Project.ProjectLeader.PartnerId,
                    Name = team.Project.ProjectLeader.Name,
                    Address = team.Project.ProjectLeader.Address,
                    City = team.Project.ProjectLeader.City,
                    Country = team.Project.ProjectLeader.Country,
                    Phone = team.Project.ProjectLeader.Phone,
                    Email = team.Project.ProjectLeader.Email,
                    ProfileImagePath = team.Project.ProjectLeader.ProfileImagePath,
                    Description = team.Project.ProjectLeader.Description,
                    SkypeLink = team.Project.ProjectLeader.SkypeLink,
                    Facebook = team.Project.ProjectLeader.Facebook,
                    LinkedIn = team.Project.ProjectLeader.LinkedIn,
                    Homepage = team.Project.ProjectLeader.Homepage,
                    Portfolio = null,
                    Competencies = null
                };

                // transform List<PortfolioSubject> til List<PortfolioSubjectModel> for project leader
                List<PortfolioSubjectModel> portfolio = new List<PortfolioSubjectModel>();
                foreach (var portSubject in team.Project.ProjectLeader.Portfolio)
                {
                    PortfolioSubjectModel portfolioSubjectModel = new PortfolioSubjectModel
                    {
                        Name = portSubject.Name,
                        Date = portSubject.Date,
                        Description = portSubject.Description,
                        Photo1 = portSubject.ImagePath1,
                        Photo2 = portSubject.ImagePath2,
                        Photo3 = portSubject.ImagePath3
                    };
                    portfolio.Add(portfolioSubjectModel);
                }
                projectLeader.Portfolio = portfolio;

                // transform List<Competency> til List<CompetencyModel> for project leader
                var competencyModels = new List<CompetencyModel>();
                foreach (var competency in team.Project.ProjectLeader.Competencies)
                {
                    CompetencyModel competencyModel = new CompetencyModel
                    {
                        CompetencyId = competency.CompetencyId,
                        Name = competency.Name,
                        Description = competency.Description
                    };
                    competencyModels.Add(competencyModel);
                }
                projectLeader.Competencies = competencyModels;
                projectModel.ProjectLeader = projectLeader;

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
                    PartnerModel partnerModel = new PartnerModel()
                    {
                        PartnerId = partner.PartnerId,
                        Name = partner.Name,
                        Address = partner.Address,
                        City = partner.City,
                        Country = partner.Country,
                        Phone = partner.Phone,
                        Email = partner.Email,
                        ProfileImagePath = partner.ProfileImagePath,
                        Description = partner.Description,
                        SkypeLink = partner.SkypeLink,
                        Facebook = partner.Facebook,
                        LinkedIn = partner.LinkedIn,
                        Homepage = partner.Homepage,
                        Portfolio = null,
                        Competencies = null
                    };

                    // transform List<PortfolioSubject> til List<PortfolioSubjectModel>
                    List<PortfolioSubjectModel> portfolioSubjects = new List<PortfolioSubjectModel>();
                    foreach (var portSubject in partner.Portfolio)
                    {
                        PortfolioSubjectModel portfolioSubjectModel = new PortfolioSubjectModel
                        {
                            Name = portSubject.Name,
                            Date = portSubject.Date,
                            Description = portSubject.Description,
                            Photo1 = portSubject.ImagePath1,
                            Photo2 = portSubject.ImagePath2,
                            Photo3 = portSubject.ImagePath3
                        };
                        portfolioSubjects.Add(portfolioSubjectModel);
                    }
                    partnerModel.Portfolio = portfolioSubjects;

                    // transform List<Competency> til List<CompetencyModel>
                    List<CompetencyModel> partnerCompetencyModels = new List<CompetencyModel>();
                    foreach (var competency in partner.Competencies)
                    {
                        CompetencyModel competencyModel = new CompetencyModel
                        {
                            CompetencyId = competency.CompetencyId,
                            Name = competency.Name,
                            Description = competency.Description
                        };
                        partnerCompetencyModels.Add(competencyModel);
                    }
                    partnerModel.Competencies = partnerCompetencyModels;
                }

            teamModels.Add(teamModel);
            }

            return teamModels;
        }
    }
}
