using IsolDesign.Domain.Handlers;
using IsolDesign.Domain.Interfaces;
using IsolDesign.Domain.Interfaces.Interfaces_Models;
using IsolDesign.Domain.Models;
using IsolDesign.WebUI.Models;
using System.Net;
using System.Web;
using System.Web.Mvc;

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
            CreateApplicantViewModel vm = new CreateApplicantViewModel();

            return View(vm);
        }

        // POST: Applicants/Create
        [HttpPost]
        public ActionResult Create(CreateApplicantViewModel model, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                IApplicantModel applicantModel = new ApplicantModel
                {
                    Name = model.Name,
                    Address = model.Address,
                    City = model.City,
                    Country = model.Country,
                    Phone = model.Phone,
                    Email = model.Email,
                    ProfileImagePath = null,
                    Description = model.Description,
                    SkypeLink = model.SkypeLink,
                    Facebook = model.Facebook,
                    LinkedIn = model.LinkedIn,
                    Homepage = model.Homepage
                };

                ICreateApplicantHandler handler = new CreateApplicantHandler(applicantModel);
                handler.SaveImage(image);
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
    }
}
