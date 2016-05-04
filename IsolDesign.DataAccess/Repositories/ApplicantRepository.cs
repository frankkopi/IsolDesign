using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess.Interfaces;
using IsolDesign.DataAccess.Models;

namespace IsolDesign.DataAccess.Repositories
{
    public class ApplicantRepository : Repository<Applicant>, IApplicantRepository
    {
        public ApplicantRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
