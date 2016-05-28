using System;

namespace IsolDesign.Domain.Interfaces.Interfaces_Models
{
    public interface IPortfolioSubjectModel
    {
        string Name { get; set; }

        DateTime Date { get; set; }

        string Description { get; set; }

        string Photo1 { get; set; }

        string Photo2 { get; set; }

        string Photo3 { get; set; }
    }
}
