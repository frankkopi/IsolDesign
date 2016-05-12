using IsolDesign.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IsolDesign.WebUI.Models
{
    public class CreateTeamViewModel
    {
        public TeamModel Team { get; set; }

        public IEnumerable<PartnerModel> Partners { get; set; }

        public IEnumerable<ProjectModel> Projects { get; set; }
    }
}