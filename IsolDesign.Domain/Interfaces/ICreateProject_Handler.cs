using IsolDesign.Domain.Models;

namespace IsolDesign.Domain.Interfaces
{
    public interface ICreateProject_Handler
    {
        void CreateProject(ProjectModel projectModel, int assignmentId);

        void Execute();
    }
}
