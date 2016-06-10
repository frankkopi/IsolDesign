using IsolDesign.DataAccess;
using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess.Interfaces.IUnitOfWork;
using IsolDesign.Domain.Interfaces;
using IsolDesign.Domain.Models;

namespace IsolDesign.Domain.Handlers
{
    public class EditCompetency_Handler : IEditCompetency_Handler
    {
        private ApplicationDbContext _context;
        private IUnitOfWork _unitOfWork;

        public EditCompetency_Handler()
        {
            this._context = new ApplicationDbContext();
            this._unitOfWork = new UnitOfWork(_context);
        }

        public void EditCompetency(CompetencyModel competencyModel)
        {
            var id = competencyModel.CompetencyId;
            var competency = _unitOfWork.Competencies.Get(id);
            competency.Name = competencyModel.Name;
            competency.Description = competencyModel.Description;

            _unitOfWork.SaveChanges();
        }
    }
}
