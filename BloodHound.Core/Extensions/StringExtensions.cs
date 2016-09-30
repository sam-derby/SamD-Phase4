using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class StringExtensions
{
    public static string FormattedTime(this string timeIn)
    {
        if (!string.IsNullOrWhiteSpace(timeIn) && timeIn.Length == 4)
        {
            return timeIn.Insert(2, ":");
        }
        return string.Empty;
    }

}

