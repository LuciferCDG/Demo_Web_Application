using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using Demo_Web_Application.Core;
using Demo_Web_Application.Models;
using Demo_Web_Application.Core.Model;
using Demo_Web_Application.Core.Repository;
using System.Web.Services;

namespace Demo_Web_Application.Controllers
{
    public class StudentController : BaseController
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewRegistrationForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewRegistrationForm(StudentDto obj, HttpPostedFileBase Photo, HttpPostedFileBase Signature)
        {

            try
            {
                var domainModel = obj.ConvertToDomianModel();
                if (obj.StudentId == 0)
                {
                    var fileName = string.Empty;
                    var signatureFileName = string.Empty;

                    if (Photo != null)
                    {
                        fileName = SaveFile(Photo, filePathType.Photo);
                        domainModel.Photo = fileName;
                    }

                    if (Signature != null)
                    {
                        signatureFileName = SaveFile(Signature, filePathType.Signature);
                        domainModel.Signature = signatureFileName;
                    }

                    UserServices.Instance().Insert(domainModel);
                    Response.Write("<script>alert('Record Saved Successfully');Window.location.href='../Student/NewRegistrationForm/'</script>");
                
                }
                else
                {

                    var fileName = string.Empty;
                    if (Photo != null)
                    {
                        fileName = SaveFile(Photo, filePathType.Photo);
                        domainModel.Photo = fileName;
                    }
                    else
                    {
                        domainModel.Photo = UserServices.Instance().GetDetailById(obj.StudentId).Photo;
                    }
                    UserServices.Instance().Update(domainModel);
                }
   
                return View();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            //return View();
        }

        public ActionResult ManageStudentRecords()
        {
            //var data = UserServices.Instance().GetAllRecords().Where(f => f.IsActive == true).Select(f => new Models.StudentDto(f)).ToList();
            var data = UserServices.Instance().GetAllRecords().Select(f => new Models.StudentDto(f)).ToList();
            return View(data);
        }

        public ActionResult DeleteStudentRecord(int Id)
        {
             UserServices.Instance().Delete(Id);
            return RedirectToAction("ManageStudentRecords", "Student");
            //try
            //{
            //    var deleted = UserServices.Instance().Delete(Id);

            //    if (deleted)
            //    {

            //        return RedirectToAction("ManageStudentRecords", "Student");
            //    }
            //    else
            //    {

            //        return Json(new { success = false, message = "Record not deleted." }, JsonRequestBehavior.AllowGet);
            //    }
            //}
            //catch (Exception ex)
            //{

            //    return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            //}
        }


    }
}