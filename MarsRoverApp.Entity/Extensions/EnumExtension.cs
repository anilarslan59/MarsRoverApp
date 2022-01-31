using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverApp.Entity.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class EnumExtension
    {
       /// <summary>
       /// 
       /// </summary>
       /// <typeparam name="T"></typeparam>
       /// <param name="value"></param>
       /// <returns></returns>
        public static T ToEnumValue<T>(this string value) where T : System.Enum
        {
            try
            {
                return (T)Enum.Parse(typeof(T), value);
            }
            catch
            {
                return default;
            }
        }
    }
}
