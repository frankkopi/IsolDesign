using IsolDesign.DataAccess.Interfaces.IUnitOfWork;
using IsolDesign.Domain.Models;
using System.Collections.Generic;

namespace IsolDesign.Domain.Interfaces
{
    public interface IGetProjects_Handler
    {
        IEnumerable<ProjectModel> GetProjects();

        IEnumerable<ProjectModel> GetAllProjects(IUnitOfWork unitOfWork);
    }
}
