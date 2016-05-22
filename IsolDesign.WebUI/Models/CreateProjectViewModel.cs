using IsolDesign.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IsolDesign.WebUI.Models
{
    public class CreateProjectViewModel
    {
        public ProjectModel Project { get; set; }

        public IEnumerable<object> PartnersInfo { get; set; } // for finding project leader

    }
}