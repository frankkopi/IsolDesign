using IsolDesign.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsolDesign.Domain.Interfaces
{
    public interface ICreateProject_Handler
    {
        void CreateProject(ProjectModel projectModel, int assignmentId);

        void Execute();
    }
}
