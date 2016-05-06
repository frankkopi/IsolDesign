using IsolDesign.Domain.Interfaces.Interfaces_Models;
using IsolDesign.Domain.Models;
using System.Web;

namespace IsolDesign.Domain.Interfaces
{
    public interface ICreateApplicantHandler
    {
        void SaveProfileImage();
        void SavePortfolioImages();
        void SaveImage(HttpPostedFileBase image, string type, int? count);
        void Execute();
    }
}
