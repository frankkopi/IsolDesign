using IsolDesign.DataAccess.Interfaces.IUnitOfWork;
using IsolDesign.Domain.Models;
using System.Collections.Generic;

namespace IsolDesign.Domain.Interfaces
{
    public interface IGetPartners_Handler
    {
        IEnumerable<PartnerModel> GetPartners();

        IEnumerable<PartnerModel> GetAllPartners(IUnitOfWork _unitOfWork);
    }
}
