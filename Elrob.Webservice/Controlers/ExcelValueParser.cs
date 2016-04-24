using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elrob.Webservice.Controlers
{
    using System.Globalization;
    using System.Text.RegularExpressions;

    using DocumentFormat.OpenXml.Spreadsheet;

    using NLog;

    public class ExcelValueParser : IExcelValueParser
    {
        private static ILogger _logger = LogManager.GetCurrentClassLogger();

        public T ParseExcelValue<T>(Cell cell, SharedStringTable sst)
        {
            if ((cell.DataType != null) && (cell.DataType == CellValues.SharedString))
            {
                int ssid = int.Parse(cell.CellValue.Text);
                string str = sst.ChildElements[ssid].InnerText;

                if (typeof(T) == typeof(string))
                {
                    return (T)(object)str.Trim();
                }
                else if (typeof(T) == typeof(int))
                {
                    int tempValue;
                    str = ExtractOnlyNumbers(str);

                    if (int.TryParse(str, NumberStyles.Any, CultureInfo.InstalledUICulture, out tempValue) == false)
                    {
                        _logger.Warn("The value [{0}] in cell [{1}] is not correct int value!", str, cell.CellReference);

                        throw new FormatException(string.Format("Wartość [{0}] w komórce [{1}] nie jest prawidłową liczbą całkowitą!", str, cell.CellReference));
                    }
                    return (T)(object)tempValue;
                }
                else if (typeof(T) == typeof(decimal) ||
                    typeof(T) == typeof(decimal?))
                {
                    decimal tempValue;
                    str = ExtractOnlyNumbers(str);

                    if (decimal.TryParse(str, NumberStyles.Any, CultureInfo.InstalledUICulture, out tempValue) == false)
                    {
                        _logger.Warn("The value [{0}] in cell [{1}] is not correct decimal value!", str, cell.CellReference);

                        throw new FormatException(string.Format("Wartość [{0}] w komórce [{1}] nie jest prawidłową liczbą zmiennoprzecinkową!", str, cell.CellReference));
                    }
                    return (T)(object)tempValue;
                }

                throw new NotSupportedException(string.Format("This type of T [{0}] is not supported!", typeof(T)));
            }
            else if (cell.CellValue != null)
            {
                string str = cell.CellValue.Text.Trim();

                if (typeof(T) == typeof(string))
                {
                    return (T)(object)str.Trim();
                }
                else if (typeof(T) == typeof(int))
                {
                    int tempValue;
                    str = ExtractOnlyNumbers(str);

                    if (int.TryParse(str, NumberStyles.Any, CultureInfo.InstalledUICulture, out tempValue) == false)
                    {
                        _logger.Warn("The value [{0}] in cell [{1}] is not correct int value!", str, cell.CellReference);

                        throw new FormatException(string.Format("Wartość [{0}] w komórce [{1}] nie jest prawidłową liczbą całkowitą!", str, cell.CellReference));
                    }
                    return (T)(object)tempValue;
                }
                else if (typeof(T) == typeof(decimal) ||
                    typeof(T) == typeof(decimal?))
                {
                    decimal tempValue;
                    str = ExtractOnlyNumbers(str);

                    if (decimal.TryParse(str, NumberStyles.Any, CultureInfo.InstalledUICulture, out tempValue) == false)
                    {
                        _logger.Warn("The value [{0}] in cell [{1}] is not correct decimal value!", str, cell.CellReference);

                        throw new FormatException(string.Format("Wartość [{0}] w komórce [{1}] nie jest prawidłową wartością zmiennoprzecinkową!", str, cell.CellReference));
                    }
                    return (T)(object)tempValue;
                }

                throw new NotSupportedException(string.Format("This type of T [{0}] is not supported!", typeof(T)));
            }

            return default(T);
        }

        private static string ExtractOnlyNumbers(string value)
        {
            string result = Regex.Replace(value, "[A-Za-z]", "");

            if (CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator == ".")
                result = result.Replace(",", ".");
            else
                result = result.Replace(".", ",");

            return result;
        }
    }
}