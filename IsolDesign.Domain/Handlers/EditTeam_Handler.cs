using IsolDesign.DataAccess;
using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess.Interfaces.IUnitOfWork;
using IsolDesign.Domain.Interfaces;

namespace IsolDesign.Domain.Handlers
{
    public class EditTeam_Handler : IEditTeam_Handler
    {
        private ApplicationDbContext _context;
        private IUnitOfWork _unitOfWork;

        public EditTeam_Handler()
        {
            this._context = new ApplicationDbContext();
            this._unitOfWork = new UnitOfWork(_context);
        }


    }
}
