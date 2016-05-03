using IsolDesign.Data.DBContext;
using IsolDesign.Data.Interfaces;
using IsolDesign.Data.Models;

namespace IsolDesign.Data.Repositories
{
    public class ApplicantRepository : Repository<Applicant>, IApplicantRepository
    {
        public ApplicantRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
