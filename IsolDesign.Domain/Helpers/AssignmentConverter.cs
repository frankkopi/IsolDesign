using IsolDesign.Data.Models;
using IsolDesign.Domain.Models;

namespace IsolDesign.Domain.Helpers
{
    public class AssignmentConverter
    {
        public static AssignmentModel ConvertToAssignmentModel(Assignment assignment)
        {
            var assignmentModel = new AssignmentModel()
            {
                AssignmentId = assignment.AssignmentId,
                WorkTitle = assignment.WorkTitle,
                Type = null,
                Description = assignment.Description,
                Photo = assignment.Photo,
                Drawing = assignment.Drawing,
                Video = assignment.Video
            };

            return assignmentModel;
        }
    }
}
