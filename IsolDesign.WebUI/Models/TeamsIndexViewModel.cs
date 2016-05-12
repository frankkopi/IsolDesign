using IsolDesign.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IsolDesign.WebUI.Models
{
    public class TeamsIndexViewModel
    {
        public IEnumerable<TeamModel> Teams { get; set; }
    }
}