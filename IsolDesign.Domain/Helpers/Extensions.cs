using System.Web;

namespace IsolDesign.Domain.Helpers
{
    public static class Extensions
    {
        // Extension method for showing if file has been uploaded
        public static bool HasFile(this HttpPostedFileBase file)
        {
            return (file != null && file.ContentLength > 0) ? true : false;
        }
        
    }
}
