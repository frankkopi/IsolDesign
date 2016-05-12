using IsolDesign.Data.Models;
using IsolDesign.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsolDesign.Domain.Helpers
{
    public class CompetencyConverter
    {
        // convert List<Competency> to List<CompetencyModel>
        public static ICollection<CompetencyModel> ConvertToCompetencyModels(ICollection<Competency> competencies)
        {
            var convertedCompetencies = new List<CompetencyModel>();

            foreach (var competency in competencies)
            {
                CompetencyModel competencyModel = new CompetencyModel
                {
                    CompetencyId = competency.CompetencyId,
                    Name = competency.Name,
                    Description = competency.Description
                };
                convertedCompetencies.Add(competencyModel);
            }
            return convertedCompetencies;
        }
    }
}
