using IsolDesign.Data.Models;
using IsolDesign.Domain.Models;

namespace IsolDesign.Domain.Helpers
{
    public class ProjectConverter
    {
        public static ProjectModel ConvertToProjectModel(Project project)
        {
            ProjectModel projectModel = new ProjectModel
            {
                ProjectId = project.ProjectId,
                Description = project.Description,
                Name = project.Name,
                StartDate = project.StartDate,
                Deadline = project.Deadline,
                PartnerId = project.PartnerId,
                DevMethodId = project.DevMethodId,
                EconomyId = project.EconomyId,
                AssignmentId = project.AssignmentId,
                ProjectLeader = null,
                Teams = null
            };
            return projectModel;
        }
    }
}
