using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suppelement
{
    public static class supl
    {
        public static string ToStringProp<T>(this T objet)
        {
            string result = "";
            foreach (PropertyInfo p in objet.GetType().GetProperty)
        }
    }
}
