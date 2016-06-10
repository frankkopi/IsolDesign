using IsolDesign.Domain.Models;
using System.Collections.Generic;

namespace IsolDesign.WebUI.Models
{
    public class CreateTeamViewModel
    {
        public TeamModel Team { get; set; }

        public PartnerModel PartnerModel { get; set; }

        public IEnumerable<PartnerModel> Partners { get; set; }

        public IEnumerable<ProjectModel> Projects { get; set; }
    }
}