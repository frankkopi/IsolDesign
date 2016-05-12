using IsolDesign.Data.Models;
using IsolDesign.DataAccess.Interfaces.IUnitOfWork;
using IsolDesign.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsolDesign.Domain.Interfaces
{
    public interface IGetProjects_Handler
    {
        IEnumerable<ProjectModel> GetProjects();

        IEnumerable<ProjectModel> GetAllProjects(IUnitOfWork unitOfWork);
    }
}
