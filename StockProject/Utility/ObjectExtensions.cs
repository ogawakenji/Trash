using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// objectがnullかどうかを判定する。
        /// </summary>
        /// <param name="target"></param>
        /// <returns>true：null、false：null以外</returns>
        public static bool IsEmpty(this object target)
        {
            if (target == null)
            {
                return true;
            }
            return false;
        }

        public static string Serialize(this object target)
        {
            if (target.IsEmpty())
            {
                return null;
            }

            return target.ToString();
            //var serializer = new XmlSerializer(target.GetType());
            //var stringWriter = new StringWriter();

            //serializer.Serialize(stringWriter, target);

            //return stringWriter.ToString();
        }

        //private static string Seri(object target, ref string val)
        //{
        //    Type targetType = target.GetType();

        //    if (targetType.IsPrimitive)
        //    {
        //        val = val + target.ToString();
        //        return null;
        //    }
        //    else
        //    {
        //        PropertyInfo[] members = targetType.GetProperties(
        //            BindingFlags.Public | BindingFlags.NonPublic |
        //            BindingFlags.Instance |
        //            BindingFlags.DeclaredOnly);

        //        foreach (PropertyInfo pr in members)
        //        {
        //            object resobj = pr.GetValue(target, null);
        //        }
        //    }
        //    return null;
        //}
    }
}
