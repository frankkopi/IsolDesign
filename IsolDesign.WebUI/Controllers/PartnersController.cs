using IsolDesign.Domain.Handlers;
using IsolDesign.Domain.Interfaces;
using IsolDesign.WebUI.Models;
using System.Web.Mvc;

namespace IsolDesign.WebUI.Controllers
{
    public class PartnersController : Controller
    {
        // GET: Partners
        [AllowAnonymous]
        public ActionResult Index()
        {
            IGetPartners_Handler handler = new GetPartners_Handler();
            var partnerModels = handler.GetPartners();

            PartnersIndexViewModel vm = new PartnersIndexViewModel()
            {
                Partners = partnerModels
            };
            return View(vm);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreatePartner(int applicantId)
        {
            ICreatePartner_Handler handler = new CreatePartner_Handler(applicantId);
            handler.CreatePartner();
            handler.Execute();

            IDelete_Handler deleteHandler = new Delete_Handler();
            deleteHandler.DeleteApplicant(applicantId);

            RegisterViewModel vm = new RegisterViewModel
            {
                Email = handler.GetPartner().Email,
                Password = "P_assword!1",
                ConfirmPassword = "P_assword!1"
            };

            return RedirectToAction("RegisterPartner", "Account", vm);
        }


        //// GET: Partners/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Partners/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Partners/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int partnerId)
        {
            GetPartners_Handler handler = new GetPartners_Handler();
            var partnerModel = handler.GetPartner(partnerId);
            
            return View(partnerModel);
        }

        // Delete a Partner and his portfolio and set PartnerId to null in Project if Partner is project leader
        // POST: Partners/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int partnerId)
        {
            try
            {
                Delete_Handler handler = new Delete_Handler();
                handler.DeletePartnerAndPortfolio(partnerId);

                return RedirectToAction("Index");
            }
            catch
            {
                GetPartners_Handler handler = new GetPartners_Handler();
                var partnerModel = handler.GetPartner(partnerId);
                return View(partnerModel);
            }
        }


        [Authorize(Roles = "Admin")]
        public ActionResult ConfirmPartnerCreated()
        {
            return View();
        }
    }
}
