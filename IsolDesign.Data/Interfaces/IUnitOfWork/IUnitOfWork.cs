using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsolDesign.Data.Interfaces.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IApplicantRepository Applicants { get; }
        IAssignmentRepository Assignments { get; }
        ICompetencyRepository Competencies { get; }
        ICustomerRepository Customers { get; }
        IDevMethodRepository DevMethods { get; }
        IEconomyRepository Economies { get; }
        IOrderedAssignmentRepository OrderedAssignments { get; }
        IPartnerAssignmentRepository PartnerAssignments { get; }
        IPartnerRepository Partners { get; }
        IPatentRepository Patents { get; }
        IPortfolioSubjectRepository PortfolioSubjects { get; }
        IProjectRepository Projects { get; }
        ISubcontractorRepository Subcontractors { get; }
        ITeamRepository Teams { get; }

        int SaveChanges();
    }
}
