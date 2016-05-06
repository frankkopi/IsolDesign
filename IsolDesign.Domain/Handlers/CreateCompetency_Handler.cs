using IsolDesign.Data.Models;
using IsolDesign.DataAccess;
using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess.Interfaces.IUnitOfWork;
using IsolDesign.Domain.Interfaces;
using IsolDesign.Domain.Interfaces.Interfaces_Models;
using IsolDesign.Domain.Models;

namespace IsolDesign.Domain.Handlers
{
    public class CreateCompetency_Handler : ICreateCompetency_Handler
    {
        private ICompetencyModel _model;
        private static Competency _competency;

        public CreateCompetency_Handler(ICompetencyModel competencyModel)
        {
            this._model = competencyModel;

            _competency = new Competency()
            {
                CompetencyId = 0,
                Name = _model.Name,
                Description = _model.Description,
                Partners = null,
                Applicants = null
            };
        }

        public void Execute()
        {
            ApplicationDbContext _context = new ApplicationDbContext();
            IUnitOfWork _unitOfWork = new UnitOfWork(_context);

            _unitOfWork.Competencies.Add(_competency);
            _unitOfWork.SaveChanges();
            _unitOfWork.Dispose();
        }

    }
}
