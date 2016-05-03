using IsolDesign.Domain.Interfaces.Interfaces_Models;
using IsolDesign.Domain.Models;
using System.Web;

namespace IsolDesign.Domain.Interfaces
{
    public interface ICreateApplicantHandler
    {
        void SaveImage(HttpPostedFileBase image);
        void Execute();
    }
}
