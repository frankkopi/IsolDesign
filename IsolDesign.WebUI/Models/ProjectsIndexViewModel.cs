using IsolDesign.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IsolDesign.WebUI.Models
{
    public class ProjectsIndexViewModel
    {
        public ProjectModel Project { get; set; }

        public IEnumerable<ProjectModel> Projects { get; set; }
    }
}