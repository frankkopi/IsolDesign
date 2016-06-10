using System.Web.Mvc;
using IsolDesign.WebUI.Models;
using IsolDesign.Domain.Models;
using IsolDesign.Domain.Interfaces.Interfaces_Models;
using IsolDesign.Domain.Interfaces;
using IsolDesign.Domain.Handlers;
using System.Net;

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

        // GET: Competencies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GetCompetencies_Handler handler = new GetCompetencies_Handler();
            CompetencyModel competencyModel = handler.GetCompetency(id);

            if (competencyModel == null)
            {
                return HttpNotFound();
            }
            return View(competencyModel);
        }

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

        // GET: Competencies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GetCompetencies_Handler handler = new GetCompetencies_Handler();
            CompetencyModel competencyModel = handler.GetCompetency(id);
            if (competencyModel == null)
            {
                return HttpNotFound();
            }
            return View(competencyModel);
        }

        // POST: Competencies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompetencyId,Name,Description")] CompetencyModel competencyModel)
        {
            if (ModelState.IsValid)
            {
                EditCompetency_Handler handler = new EditCompetency_Handler();
                handler.EditCompetency(competencyModel);

                return RedirectToAction("Index");
            }
            return View(competencyModel);
        }

        // GET: Competencies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GetCompetencies_Handler handler = new GetCompetencies_Handler();
            var competencyModel = handler.GetCompetency(id);
            if (competencyModel == null)
            {
                return HttpNotFound();
            }
            return View(competencyModel);
        }

        // POST: Competencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Delete_Handler handler = new Delete_Handler();
            handler.DeleteCompetency(id);

            return RedirectToAction("Index");
        }

    }
}
