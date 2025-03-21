using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApp1.Converters
{
    public class NumericConverter : IValueConverter
    {
        private readonly static char NumberStart = '0';
        private readonly static char NumberEnd = '9';
        private readonly static char DecimalSeparator = '.';
        private readonly static char MinusSign = '-';
        private readonly static char PlusSign = '+';
        private readonly static char FullWidthNumberStart = '０';
        private readonly static char FullWidthNumberEnd = '９';

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is decimal decimalValue)
            {
                return decimalValue.ToString(parameter?.ToString());
            }
            else if (value is double doubleValue)
            {
                return doubleValue.ToString(parameter?.ToString());
            }
            else if (value is float floatValue)
            {
                return floatValue.ToString(parameter?.ToString());
            }
            else if (value is int intValue)
            {
                return intValue.ToString(parameter?.ToString());
            }
            else
            {
                if (value is string stringValue)
                {
                    return ConvertToHalfWidth(stringValue);
                }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value is string stringvValue)
            {
                return ConvertToHalfWidth(stringvValue);
            }
            return value;
        }
        private string ConvertToHalfWidth(string input)
        {
            List<char> result = new List<char>();
            foreach(var c in input)
            {
                if (c >= NumberStart && c <= NumberEnd)
                {
                    result.Add(c);
                }
                else if (c == DecimalSeparator)
                {
                    if (!result.Any(x => x == DecimalSeparator))
                    {
                        result.Add(c);
                    }
                }
                else if (c == MinusSign)
                {
                    if(!result.Any())
                    {
                        result.Add(c);
                    }
                }
                else if (c == PlusSign)
                {
                    if (!result.Any())
                    {
                        result.Add(PlusSign);
                    }
                }
                else if (c >= FullWidthNumberStart && c <= FullWidthNumberEnd)
                {
                    result.Add((char)(c - FullWidthNumberStart + NumberStart));
                }
            }

            return new string(result.ToArray());
        }
    }
}
