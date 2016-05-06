using IsolDesign.Domain.Models;
using System.Collections.Generic;

namespace IsolDesign.Domain.Interfaces.Interfaces_Models
{
    public interface IApplicantModel
    {
        string Name { get; set; }
        string Address { get; set; }
        string City { get; set; }
        string Country { get; set; }
        string Phone { get; set; }
        string Email { get; set; }
        string ProfileImagePath { get; set; }
        string Description { get; set; }
        string SkypeLink { get; set; }
        string Facebook { get; set; }
        string LinkedIn { get; set; }
        string Homepage { get; set; }
        ICollection<PortfolioSubjectModel> Portfolio { get; set; }
    }
}
