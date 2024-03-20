using Demo_Web_Application.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Web_Application.Core.Repository.CommonServices
{
    public partial class UserServices : BaseRepository<Student>
    {
        private static UserServices obj; private UserServices() { }
        public static UserServices Instance() { if (obj == null) { obj = new UserServices(); } return obj; }

    }

    public partial class CourseServices : BaseRepository<Course>
    {
        private static CourseServices obj; private CourseServices() { }
        public static CourseServices Instance() { if (obj == null) { obj = new CourseServices(); } return obj; }

    }

}
