using IsolDesign.Domain.Handlers;
using IsolDesign.Domain.Interfaces;
using IsolDesign.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IsolDesign.WebUI.Controllers
{
    public class PartnersController : Controller
    {
        // GET: Partners
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

        //// GET: Partners/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //public ActionResult CreatePartner(int applicantId)
        //{
        //    ICreatePartner_Handler handler = new CreatePartner_Handler(applicantId);
        //    handler.CreatePartner();
        //    handler.Execute();

        //    IDelete_Handler deleteHandler = new Delete_Handler();
        //    deleteHandler.DeleteApplicant(applicantId);

        //    return RedirectToAction("ConfirmPartnerCreated");
        //}

        //public ActionResult ConfirmPartnerCreated()
        //{
        //    return View();
        //}

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

        //// GET: Partners/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Partners/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
