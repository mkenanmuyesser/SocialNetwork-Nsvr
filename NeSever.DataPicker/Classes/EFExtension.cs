using System;
using System.Collections.Generic;

namespace DataPickerProject.Classes
{
    public static class EFExtension
    {
        public static IEnumerable<T> SetValue<T>(this IEnumerable<T> items, Action<T> updateMethod)
        {
            foreach (T item in items)
            {
                updateMethod(item);
            }
            return items;
        }
    }
}
