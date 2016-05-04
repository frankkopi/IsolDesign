using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess.Interfaces;
using IsolDesign.DataAccess.Models;
using IsolDesign.DataAccess.Repositories;

namespace IsolDesign.DataAccess.Repository
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
