using IsolDesign.Domain.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace IsolDesign.WebUI.Models
{
    public class EditTeamViewModel
    {
        public TeamModel Team { get; set; }

        public SelectList ProjectsSelectList { get; set; }

        public PartnerModel PartnerModel { get; set; }

        public IEnumerable<PartnerModel> Partners { get; set; }

        public IEnumerable<ProjectModel> Projects { get; set; }
    }
}