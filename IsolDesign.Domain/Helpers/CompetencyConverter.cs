using IsolDesign.Data.Models;
using IsolDesign.Domain.Models;
using System.Collections.Generic;

namespace IsolDesign.Domain.Helpers
{
    public class CompetencyConverter
    {
        // convert List<Competency> to List<CompetencyModel>
        public static List<CompetencyModel> ConvertToCompetencyModels(ICollection<Competency> competencies)
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


        // convert List<Competency> to List<CompetencyModel>
        public static List<CompetencyModel> ConvertToCompetencyModels2(IEnumerable<Competency> competencies)
        {
            var convertedCompetencies = new List<CompetencyModel>();

            foreach (var competency in competencies)
            {
                CompetencyModel competencyModel = new CompetencyModel
                {
                    CompetencyId = competency.CompetencyId,
                    Name = competency.Name,
                    Description = competency.Description,
                    Applicants = null,
                    Partners = null
                };
                convertedCompetencies.Add(competencyModel);
            }
            return convertedCompetencies;
        }

        // convert a Competency to a CompetencyModel
        public static CompetencyModel ConvertToCompetencyModel(Competency competency)
        {
            CompetencyModel competencyModel = new CompetencyModel
            {
                CompetencyId = competency.CompetencyId,
                Name = competency.Name,
                Description = competency.Description
            };

            return competencyModel;
        }
    }
}
