using System.ComponentModel;
using System.Reflection;

namespace BattleShipStateTracker.Core.Helper
{
    public static class EnumExtensionMethods
    {
        public static string GetEnumDescription<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }
    }
}
