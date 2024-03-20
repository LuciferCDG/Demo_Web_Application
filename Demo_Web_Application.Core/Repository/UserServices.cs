using Demo_Web_Application.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Web_Application.Core.Repository
{
    public class UserServices : BaseRepository<Student>
    {

        #region 

        private static UserServices obj;

        private UserServices() { }

        public static UserServices Instance()
        {

            if (obj == null)
                obj = new UserServices();
            return obj;
        }

        #endregion

        public Student GetDetailById(int Id)
        {
            using (var context = new Demo_DBEntities())
            {
                var tb = context.Students.FirstOrDefault(cond => cond.StudentId == Id);
                return tb;
            }
        }
        public List<Student> GetAllStudents()
        {
            using (var context = new Demo_DBEntities())

                return context.Students.ToList();

        }
        public int CreateUser(Student reg)
        {
            using (var context = new Demo_DBEntities())
            {
                reg.IsActive = true;
                reg.CreatedDate = DateTime.Now;
                context.Students.Add(reg);
                context.SaveChanges();
            }
            return reg.StudentId;
        }

        public void UpdateUser(Student reg)
        {
            using (var context = new Demo_DBEntities())
            {
                var edit = context.Students.FirstOrDefault(cond => cond.StudentId == reg.StudentId);

                edit.StuName = reg.StuName;
                edit.FName = reg.FName;
                edit.DOB = reg.DOB;
                edit.Gender = reg.Gender;
                edit.Mobile = reg.Mobile;
                edit.StuEmail =reg.StuEmail;
                edit.Locality = reg.Locality;
                edit.Address = reg.Address;
                edit.City = reg.City;
                edit.State = reg.State;
                edit.Country = reg.Country;
                context.SaveChanges();
            }
        }

        public void DeleteUser(int Id)
        {
            using (var context = new Demo_DBEntities())
            {
                var data = context.Students.FirstOrDefault(cond => cond.StudentId == Id);
                context.Students.Remove(data);
                context.SaveChanges();

            }
        }



    }
}
