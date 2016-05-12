using IsolDesign.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IsolDesign.WebUI.Models
{
    public class PartnersIndexViewModel
    {
        public IEnumerable<PartnerModel> Partners { get; set; }
    }
}