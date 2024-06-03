using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonReservationData.Utils
{
    public static class EnumHelper
    {
        public static string GetEnumDescription<TEnum>(int value) where TEnum : Enum
        {
            var type = typeof(TEnum);
            var name = Enum.GetName(type, value);
            if (name == null)
            {
                return null;
            }

            var field = type.GetField(name);
            var attribute = field.GetCustomAttribute<DescriptionAttribute>();
            return attribute?.Description ?? name;
        }
    }
}
