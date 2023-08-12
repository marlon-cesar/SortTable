using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace SortTable.Helpers
{
    public static class Utils
    {
        public static string GetDisplayName(this PropertyInfo property)
        {
            var displayName = property.GetCustomAttributes(typeof(DisplayAttribute), false).Cast<DisplayAttribute>()?.FirstOrDefault()?.Name;

            if (string.IsNullOrEmpty(displayName))
                displayName = property.Name;

            return displayName;
        }
    }
}
