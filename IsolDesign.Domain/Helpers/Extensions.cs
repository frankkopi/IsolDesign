using IsolDesign.Data.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
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

        //public static string GetDisplayName(this Enum enumValue)
        //{
        //    return enumValue.GetType().GetMember(enumValue.ToString())
        //                   .First()
        //                   .GetCustomAttribute<DisplayAttribute>()
        //                   .Name;
        //}

    }
}
