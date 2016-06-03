using IsolDesign.Domain.Models;
using System.Collections.Generic;

namespace IsolDesign.Domain.Helpers
{
    public class Dropdownlist_Helper
    {
        public static List<object> PopulateProjectsList(IEnumerable<ProjectModel> projectModels)
        {
            List<object> list = new List<object>();
            foreach(var project in projectModels)
            {
                var projectLeader = "";
                if (project.ProjectLeader == null)
                {
                    projectLeader = "No Project Leader";
                }
                else
                {
                    projectLeader = "Project Leader: " + project.ProjectLeader.Name;
                }
                list.Add(new {
                    ProjectId = project.ProjectId,
                    ProjectLeader = project.Name + " - " + projectLeader
                });
            }

            return list;
        }
    }
}
