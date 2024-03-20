using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Demo_Web_Application.Core.Model;
using Demo_Web_Application.Core.Repository;
using System.Text;

namespace Demo_Web_Application.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base

        //public ActionResult Index()
        //{
        //    return View();
        //}

        public BaseController()
        {
            ViewBag.UserTypeId = GetUserTypeId();
            ViewBag.LoginUserId = GetCurrentUser();
        }
        public enum CookieKeys
        {
            UserId, UserName, Email, UserType, UserTypeId, DefaultVendorId, AdminLogin
        }

        public static long GetCurrentUser()
        {
            var cookie = System.Web.HttpContext.Current.Request.Cookies["userData"];

            if (cookie != null)
            {
                if (cookie[CookieKeys.UserId.ToString()] != null)
                    return Convert.ToInt64(cookie[CookieKeys.UserId.ToString()]);
            }
            return 0;
        }

        public static string GetCurrentUserEmail()
        {
            var cookie = System.Web.HttpContext.Current.Request.Cookies["userData"];

            if (cookie != null)
            {
                if (cookie[CookieKeys.Email.ToString()] != null)
                    return cookie[CookieKeys.UserId.ToString()].ToString();
            }
            return "";
        }

        public static long GetUserTypeId()
        {
            var cookie = System.Web.HttpContext.Current.Request.Cookies["userData"];
            if (cookie != null)
            {
                if (cookie[CookieKeys.UserId.ToString()] != null)
                    return Convert.ToInt32(cookie[CookieKeys.UserTypeId.ToString()]);
            }
            return 0;
        }

        public static long GetDefaultVendorId()
        {
            var cookie = System.Web.HttpContext.Current.Request.Cookies["userData"];
            if (cookie != null)
            {
                if (cookie[CookieKeys.DefaultVendorId.ToString()] != null)
                    return Convert.ToInt32(cookie[CookieKeys.DefaultVendorId.ToString()]);
            }
            return 0;
        }

        public static bool IsSystemUser()
        {
            var cookie = System.Web.HttpContext.Current.Request.Cookies["userData"];
            if (cookie != null)
            {
                if (cookie[CookieKeys.UserTypeId.ToString()] != null)
                {
                    var userType = Convert.ToInt32(cookie[CookieKeys.UserTypeId.ToString()]);

                    if (userType == (int)Core.Helper.UserTypeName.SystemAdmin)
                        return true;
                    else
                        return false;
                }


            }
            return false;
        }
        public static bool IsVendorLogin()
        {
            var cookie = System.Web.HttpContext.Current.Request.Cookies["userData"];
            if (cookie != null)
            {
                if (cookie[CookieKeys.UserTypeId.ToString()] != null)
                {
                    var userType = Convert.ToInt32(cookie[CookieKeys.UserTypeId.ToString()]);

                    if (userType == (int)Core.Helper.UserTypeName.VendorAdmin)
                        return true;
                    else
                        return false;
                }


            }
            return false;
        }

        public void SetLoginCookie(long userId, string userName, string email, string userType, long? userTypeId
            , long? vendorId, string adminLogin = "")
        {
            var userData = new HttpCookie("userData");
            userData[CookieKeys.UserId.ToString()] = userId.ToString();
            userData[CookieKeys.UserName.ToString()] = userName;
            userData[CookieKeys.Email.ToString()] = email;

            userData[CookieKeys.UserTypeId.ToString()] = userTypeId.GetValueOrDefault().ToString();
            userData[CookieKeys.UserType.ToString()] = userType;

            userData[CookieKeys.DefaultVendorId.ToString()] = vendorId.GetValueOrDefault().ToString();
            userData[CookieKeys.AdminLogin.ToString()] = adminLogin;


            userData.Expires = DateTime.Now.AddDays(1d);
            Response.Cookies.Add(userData);
        }

        public static string CreateRandomPassword(int passwordLength)
        {
            string _allowedChars = "0123456789abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ";
            Random randNum = new Random();
            char[] chars = new char[passwordLength];
            for (int i = 0; i < passwordLength; i++)
            {
                chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
            }
            return new string(chars);
        }

        public string RenderRazorViewToString(string viewName, object model)
        {

            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);

                var viewContext = new ViewContext(ControllerContext, viewResult.View,
                                             ViewData, TempData, sw);

                viewResult.View.Render(viewContext, sw);

                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);

                return sw.GetStringBuilder().ToString();
            }
        }


        public enum filePathType
        {
            Profile,
            Photo,
            Signature,

        }


        public string SaveFile(HttpPostedFileBase file, filePathType fileType)
        {
            var serverFilePath = string.Empty;
            switch (fileType)
            {
                   
                case filePathType.Photo:
                    serverFilePath = "~/Content/Profile/";
                    break;
                case filePathType.Signature:
                    serverFilePath = "~/Content/Signature/";
                    break;
                case filePathType.Profile:
                    serverFilePath = "~/Content/otherDetailImage/";
                    break;

            }
            var serverPath = Server.MapPath(serverFilePath);

            if (!Directory.Exists(serverPath))
                Directory.CreateDirectory(serverPath);

            var fileExist = Path.GetExtension(file.FileName);
            var fileName = Guid.NewGuid();

            var completeFile = string.Format("{0}{1}", fileName, fileExist);
            var completePath = Path.Combine(serverPath, completeFile);
            file.SaveAs(completePath);

            return completeFile;

        }

        public string GetDisplayImagePath(string fileName, filePathType fileType)
        {
            switch (fileType)
            {

                case filePathType.Photo:
                    return "~/Content/Profile/" + fileName;
                case filePathType.Signature:
                    return "~/Content/Signature/" + fileName;
                case filePathType.Profile:
                    return "~/Content/Insurance/" + fileName;
                
            }
            return "~/ProfilePicture/user1.jpg";
        }

        
        #region Date Time Basic Functions 

        public int GetTotalOfMonths(DateTime startDate, DateTime endDate)
        {
            int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
            return Math.Abs(monthsApart);
        }

        public static int GetTotalDays(DateTime startDate, DateTime endDate)
        {
            double totalDays = (endDate - startDate).TotalDays;
            return Convert.ToInt32(totalDays);
        }
        #endregion


        #region Generate Random String

        private static Random RNG = new Random();

        public string Create8DigitString()
        {
            var builder = new StringBuilder();
            while (builder.Length < 8)
            {
                builder.Append(RNG.Next(10).ToString());
            }
            return builder.ToString();
        }

        public string Create16DigitString()
        {
            var builder = new StringBuilder();
            while (builder.Length < 8)
            {
                builder.Append(RNG.Next(10).ToString());
            }
            return builder.ToString();
        }

        #endregion

    }
}