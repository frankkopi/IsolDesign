using IsolDesign.Domain.Models;

namespace IsolDesign.Domain.Interfaces.Interfaces_Models
{
    public interface IAssignmentModel
    {
        string WorkTitle { get; set; }
        AssignmentType? Type { get; set; }
        string Description { get; set; }
        string Photo { get; set; }
        string Drawing { get; set; }
        string Video { get; set; }
    }
}
