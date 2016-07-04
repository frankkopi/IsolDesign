using IsolDesign.Domain.Handlers;
using IsolDesign.Domain.Interfaces;
using IsolDesign.Domain.Models;
using IsolDesign.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace IsolDesign.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ApplicantsController : Controller
    {

        // GET: Applicants
        public ActionResult Index()
        {
            IGetApplicants_Handler handler = new GetApplicants_Handler();
            var applicantModels = handler.GetApplicants();

            ApplicantsIndexViewModel vm = new ApplicantsIndexViewModel
            {
                Applicants = applicantModels
            };
            return View(vm);
        }

        // GET: Applicants/Create
        [AllowAnonymous]
        public ActionResult Create()
        {
            IGetCompetencies_Handler handler = new GetCompetencies_Handler();
            var competencies = handler.GetCompetencies();

            ApplicantModel applicantModel = new ApplicantModel();
            PortfolioSubjectModel port1 = new PortfolioSubjectModel();
            port1.Date = DateTime.Today;
            PortfolioSubjectModel port2 = new PortfolioSubjectModel();
            port2.Date = DateTime.Today;

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
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Create(CreateApplicantViewModel model, IEnumerable<int> competencyIds)
        {
            if (ModelState.IsValid)
            {
                var images = Request.Files;
                var applicantModel = model.ApplicantModel;

                ICreateApplicant_Handler handler = new CreateApplicant_Handler(applicantModel, images, model.PortfolioSubject1, model.PortfolioSubject2, competencyIds);
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


        [AllowAnonymous]
        public ActionResult ThanxForApplication(ThanxForApplicationViewModel vm)
        {           
            return View(vm);
        }

        // GET: Applicants/Delete/5
        [HttpGet]
        public ActionResult Delete(int applicantId)
        {
            IGetApplicants_Handler handler = new GetApplicants_Handler();
            var applicantModel = handler.GetApplicant(applicantId);

            ApplicantDeleteViewModel vm = new ApplicantDeleteViewModel
            {
                ApplicantId = applicantModel.ApplicantId,
                Name = applicantModel.Name,
                Address = applicantModel.Address,
                City = applicantModel.City,
                Country = applicantModel.Country,
                Phone = applicantModel.Phone,
                Email = applicantModel.Email,
                ProfileImagePath = applicantModel.ProfileImagePath
            };
            return View(vm);
        }

        // Delete an applicant and his/her portfolio
        // POST: /Students/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int applicantId)
        {
            IDelete_Handler handler = new Delete_Handler();
            handler.DeleteApplicantAndPortfolio(applicantId);

            return RedirectToAction("Index");
        }

        public ActionResult CheckApplicant(int applicantId, string name)
        {
            ViewBag.ApplicantID = applicantId;
            ViewBag.ApplicantName = name;
            return View();
        }

        public ActionResult SaveAsPartner(int applicantId)
        {
            return RedirectToAction("CreatePartner", "Partners", new { applicantId = applicantId});
        }

        public ActionResult DismissAsPartner()
        {
            return RedirectToAction("Index");
        }
    }
}
