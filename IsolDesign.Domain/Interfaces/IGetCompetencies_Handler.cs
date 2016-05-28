using IsolDesign.Domain.Models;
using System.Collections.Generic;

namespace IsolDesign.Domain.Interfaces
{
    public interface IGetCompetencies_Handler
    {
        IEnumerable<CompetencyModel> GetCompetencies();
    }
}
