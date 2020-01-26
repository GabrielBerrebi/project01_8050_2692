using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSi;






namespace DAL
{
   public static  class DalFactory
    {
        private   static Idal instance = null;
        static DalFactory() {}
        public static Idal Instance
        {
            get
            {
                if (instance==null)
                {
                    instance = new Dal_imp();
                }
                return instance;
            }
        }

    }
}
