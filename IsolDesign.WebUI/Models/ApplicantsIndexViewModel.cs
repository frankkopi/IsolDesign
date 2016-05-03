using IsolDesign.Data.Models;
using IsolDesign.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IsolDesign.WebUI.Models
{
    public class ApplicantsIndexViewModel
    {
        public IEnumerable<ApplicantModel> Applicants { get; set; }

    }
}