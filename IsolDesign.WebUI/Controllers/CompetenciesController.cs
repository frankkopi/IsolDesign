using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IsolDesign.Data.Models;
using IsolDesign.DataAccess.DBContext;
using IsolDesign.WebUI.Models;
using IsolDesign.Domain.Models;
using IsolDesign.Domain.Interfaces.Interfaces_Models;
using IsolDesign.Domain.Interfaces;
using IsolDesign.Domain.Handlers;

namespace IsolDesign.WebUI.Controllers
{
    public class CompetenciesController : Controller
    {
        // GET: Competencies
        public ActionResult Index()
        {
            IGetCompetencies_Handler handler = new GetCompetencies_Handler();
            var competencies = handler.GetCompetencies();

            return View(competencies);
        }

        //// GET: Competencies/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Competency competency = db.Competencies.Find(id);
        //    if (competency == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(competency);
        //}

        // GET: Competencies/Create
        public ActionResult Create()
        {
            ICompetencyModel competencyModel = new CompetencyModel();
            CreateCompetencyViewModel vm = new CreateCompetencyViewModel();
            return View(vm);
        }

        // POST: Competencies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCompetencyViewModel model)
        {
            if (ModelState.IsValid)
            {
                var competencyModel = model.CompetencyModel;

                ICreateCompetency_Handler handler = new CreateCompetency_Handler(competencyModel);
                handler.Execute();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        //// GET: Competencies/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Competency competency = db.Competencies.Find(id);
        //    if (competency == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(competency);
        //}

        //// POST: Competencies/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "CompetencyId,Name,Description")] Competency competency)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(competency).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(competency);
        //}

        //// GET: Competencies/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Competency competency = db.Competencies.Find(id);
        //    if (competency == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(competency);
        //}

        //// POST: Competencies/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Competency competency = db.Competencies.Find(id);
        //    db.Competencies.Remove(competency);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
