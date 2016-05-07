using IsolDesign.Domain.Handlers;
using IsolDesign.Domain.Interfaces;
using IsolDesign.Domain.Models;
using IsolDesign.WebUI.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace IsolDesign.WebUI.Controllers
{
    public class ApplicantsController : Controller
    {

        // GET: Applicants
        public ActionResult Index()
        {
            IGetApplicants_Handler handler = new GetApplicants_Handler();
            var applicants = handler.GetApplicants();

            ApplicantsIndexViewModel vm = new ApplicantsIndexViewModel
            {
                Applicants = applicants
            };
            
            return View(vm);
        }

        // GET: Applicants/Create
        public ActionResult Create()
        {
            IGetCompetencies_Handler handler = new GetCompetencies_Handler();
            var competencies = handler.GetCompetencies();

            ApplicantModel applicantModel = new ApplicantModel();
            PortfolioSubjectModel port1 = new PortfolioSubjectModel();
            PortfolioSubjectModel port2 = new PortfolioSubjectModel();

            CreateApplicantViewModel vm = new CreateApplicantViewModel()
            {
                ApplicantModel = applicantModel,
                PortfolioSubject1 = port1,
                PortfolioSubject2 = port2,
                Competencies = competencies
            };

            return View(vm);
        }

        // POST: Applicants/Create
        [HttpPost]
        public ActionResult Create(CreateApplicantViewModel model, IEnumerable<int> competencyIds)
        {
            if (ModelState.IsValid)
            {
                var images = Request.Files;
                var applicantModel = model.ApplicantModel;

                ICreateApplicantHandler handler = new CreateApplicantHandler(applicantModel, images, model.PortfolioSubject1, model.PortfolioSubject2, competencyIds);
                handler.SaveProfileImage();
                handler.SavePortfolioImages();
                handler.Execute();

                ThanxForApplicationViewModel vm = new ThanxForApplicationViewModel
                {
                    Name = applicantModel.Name,
                    Email = applicantModel.Email
                };
                return RedirectToAction("ThanxForApplication", vm);
            }

            return RedirectToAction("Index");
        }


        public ActionResult ThanxForApplication(ThanxForApplicationViewModel vm)
        {           
            return View(vm);
        }

        // GET: Applicants/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            GetApplicants_Handler handler = new GetApplicants_Handler();
            var item = handler.GetApplicant(id);
            ApplicantDeleteViewModel vm = new ApplicantDeleteViewModel
            {
                ApplicantId = item.ApplicantId,
                Name = item.Name,
                Address = item.Address,
                City = item.City,
                Country = item.Country,
                Phone = item.Phone,
                Email = item.Email,
                ProfileImagePath = item.ProfileImagePath,
            };
            return View(vm);
        }

        // POST: /Students/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // TODO: Add delete logic here
                IDelete_Handler handler = new Delete_Handler();
                handler.DeleteApplicant(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CheckApplicant(int applicantId, string name)
        {
            ViewBag.ApplicantID = applicantId;
            ViewBag.ApplicantName = name;
            return View();
        }

        public void SaveAsPartner(int applicantId)
        {

        }
    }
}
