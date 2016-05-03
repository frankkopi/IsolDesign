using IsolDesign.Data.DBContext;
using IsolDesign.Data.Interfaces;
using IsolDesign.Data.Models;
using IsolDesign.Data.Repositories;

namespace IsolDesign.Data.Repository
{
    public class PartnerRepository : Repository<Partner>, IPartnerRepository
    {
        public PartnerRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
