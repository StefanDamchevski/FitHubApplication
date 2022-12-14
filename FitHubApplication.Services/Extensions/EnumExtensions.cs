using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace FitHubApplication.Services.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Converts enum to string according to enums <see cref="DisplayAttribute"/>
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .GetName();
        }

        /// <summary>
        /// Converts a string to enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this string value)
        {
            try
            {
                T res = (T)Enum.Parse(typeof(T), value);

                if (!Enum.IsDefined(typeof(T), res))
                {
                    return default;
                }

                return res;
            }
            catch
            {
                return default;
            }
        }
    }
}
