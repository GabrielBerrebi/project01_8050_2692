using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BLfactory
    {
        private static IBL instance = null;
        static BLfactory() { }
        public static IBL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BL_imp();
                }
                return instance;
            }
        }
    }
}
