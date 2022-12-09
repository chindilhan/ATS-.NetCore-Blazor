using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Stx.CompLibrary
{
    public class KlaInputDateCode : InputBase<DateTime>
    {
        protected const string format = "yyyy-MM-dd";
        protected override bool TryParseValueFromString(string value, out DateTime result, out string validationErrorMessage)
        {
            bool success = DateTime.TryParseExact(value, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
            if (!success)
            {
                validationErrorMessage = $"Unable to parse a System.DateTime from \"{value}\"";
            }
            else
            {
                validationErrorMessage = null;
            }
            return success;
        }

        protected string FormatDateTimeValue(DateTime value)
        {
            return value.ToString(format, CultureInfo.InvariantCulture);
        }

        protected string ReformatDateTimeString(string value)
        {
            DateTime date;
            string validationError;
            var res = TryParseValueFromString(value, out date, out validationError);
            return FormatDateTimeValue(date);
        }

        protected string CurrentFormattedValueAsString
        {
            get => FormatDateTimeValue(CurrentValue);
            set
            {
                CurrentValueAsString = ReformatDateTimeString(value);
            }
        }
    }
}