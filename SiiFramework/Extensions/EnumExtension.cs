using System;

namespace SiiFramework.Extensions
{
    public static class EnumExtension
    {
        public static T ToEnum<T>(this string value, bool ignoreCase = true)
        {
            return (T) Enum.Parse(typeof(T), value, ignoreCase);
        }
    }
}