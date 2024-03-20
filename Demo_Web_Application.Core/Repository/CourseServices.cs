using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Web_Application.Core.Repository
{
    public class CourseServices
    {

        #region 

        private static CourseServices obj;

        private CourseServices() { }

        public static CourseServices Instance()
        {

            if (obj == null)
                obj = new CourseServices();
            return obj;
        }

        #endregion



    }
}
