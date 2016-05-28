using System.Web;

namespace IsolDesign.Domain.Interfaces
{
    public interface ICreateApplicant_Handler
    {
        void SaveProfileImage();
        void SavePortfolioImages();
        void SaveImage(HttpPostedFileBase image, string type, int? count);
        void Execute();
    }
}
