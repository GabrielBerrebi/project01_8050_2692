using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;




namespace outils
{
    public static class Tools
    {
        public static String TostringProperties<T>(this T t)
        {
            string result = "";
            foreach (PropertyInfo p in t.GetType().GetProperties())
            {
                if (!(p.PropertyType is IEnumerable))
                {
                    result += String.Format("{0,-25} , {1}\n", p.Name, p.GetValue(t, null));
                }
                else
                {
                    result += String.Format("{0,-25} , {1}\n", p.Name, p.GetValue(t, new object[0]));

                }
            }
            return result;
        }
        public static T[] Flatten<T>(this T[,] arr)
        {
            int rows = arr.GetLength(0);
            int columns = arr.GetLength(1);
            T[] arrFlattened = new T[rows * columns];
            for (int j = 0; j < columns; j++)
            {
                for (int i = 0; i < rows; i++)
                {
                    var test = arr[i, j];
                    arrFlattened[i + j * rows] = arr[i, j];
                }
            }
            return arrFlattened;
        }

        public static T[,] Expand<T>(this T[] arr, int rows)
        {
            int length = arr.GetLength(0);
            int columns = length / rows;
            T[,] arrExpanded = new T[rows, columns];
            for (int j = 0; j < rows; j++)
            {
                for (int i = 0; i < columns; i++)
                {
                    arrExpanded[i, j] = arr[i + j * rows];
                }
            }
            return arrExpanded;
        }
    }

}