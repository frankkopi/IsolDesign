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
            this.OrderedAssignments = new OrderedAssignmentRepository(_context);
            this.PartnerAssignments = new PartnerAssignmentRepository(_context);
            this.Partners = new PartnerRepository(_context);
            this.Patents = new PatentRepository(_context);
            this.PortfolioSubjects = new PortfolioSubjectRepository(_context);
            this.Projects = new ProjectRepository(_context);
            this.Subcontractors = new SubcontractorRepository(_context);
            this.Teams = new TeamRepository(_context);
        }

        public IApplicantRepository Applicants { get; private set; }
        public IAssignmentRepository Assignments { get; private set; }       
        public ICompetencyRepository Competencies { get; private set; }
        public ICustomerRepository Customers { get; private set; }
        public IDevMethodRepository DevMethods { get; private set; }
        public IEconomyRepository Economies { get; private set; }
        public IOrderedAssignmentRepository OrderedAssignments { get; private set; }
        public IPartnerAssignmentRepository PartnerAssignments { get; private set; }
        public IPartnerRepository Partners { get; private set; }
        public IPatentRepository Patents { get; private set; }
        public IPortfolioSubjectRepository PortfolioSubjects { get; private set; }
        public IProjectRepository Projects { get; private set; }
        public ISubcontractorRepository Subcontractors { get; private set; }
        public ITeamRepository Teams { get; private set; }

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
