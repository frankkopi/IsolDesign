using IsolDesign.DataAccess.Interfaces.IUnitOfWork;
using IsolDesign.DataAccess.Interfaces;
using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess.Repository;
using ISolDesign.DataAccess.Repositories;
using IsolDesign.DataAccess.Repositories;

namespace IsolDesign.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            this._context = context;

            this.Applicants = new ApplicantRepository(_context);
            this.Assignments = new AssignmentRepository(_context);
            this.Competencies = new CompetencyRepository(_context);
            this.Customers = new CustomerRepository(_context);
            this.DevMethods = new DevMethodRepository(_context);
            this.Economies = new EconomyRepository(_context);
            this.Partners = new PartnerRepository(_context);
            this.Patents = new PatentRepository(_context);
            this.PortfolioSubjects = new PortfolioSubjectRepository(_context);
            this.Projects = new ProjectRepository(_context);
            this.Subcontractors = new SubcontractorRepository(_context);
            this.Teams = new TeamRepository(_context);
        }

        public IApplicantRepository Applicants { get; set; }
        public IAssignmentRepository Assignments { get; set; }       
        public ICompetencyRepository Competencies { get; set; }
        public ICustomerRepository Customers { get; set; }
        public IDevMethodRepository DevMethods { get; set; }
        public IEconomyRepository Economies { get; set; }
        public IOrderedAssignmentRepository OrderedAssignments { get; set; }
        public IPartnerAssignmentRepository PartnerAssignments { get; set; }
        public IPartnerRepository Partners { get; set; }
        public IPatentRepository Patents { get; set; }
        public IPortfolioSubjectRepository PortfolioSubjects { get; set; }
        public IProjectRepository Projects { get; set; }
        public ISubcontractorRepository Subcontractors { get; set; }
        public ITeamRepository Teams { get; set; }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
       
    }
}
