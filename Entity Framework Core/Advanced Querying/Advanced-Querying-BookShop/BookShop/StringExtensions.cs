using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop
{
    public static class StringExtensions
    {
        public static bool SensitiveContains(this string[] source, string toCheck, StringComparison comp)
        {
            foreach (var item in source)
            {
                var result = item.IndexOf(toCheck, comp) >= 0;

                if (result == false)
                {
                    return false;
                }
            }
            
            return true;
        }
    }
}
