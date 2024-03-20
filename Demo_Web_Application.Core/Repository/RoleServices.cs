using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Web_Application.Core.Repository
{
    public class RoleServices
    {

        #region 

        private static RoleServices obj;

        private RoleServices() { }

        public static RoleServices Instance()
        {

            if (obj == null)
                obj = new RoleServices();
            return obj;
        }

        #endregion


    }
}
