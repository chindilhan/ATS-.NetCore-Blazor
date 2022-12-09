using Microsoft.AspNetCore.Components.Forms;
using System.Linq.Expressions;
using System.Globalization;
using Stx.Shared.Common;
using System;
using Microsoft.AspNetCore.Components;

namespace Stx.CompLibrary.Core
{
	public class StxInputBase<T> : InputBase<T>
	{
        private const string DateFormat = "yyyy-MM-ddTHH:mm";
        protected override bool TryParseValueFromString(string value, out T result, out string validationErrorMessage)
        {
       
            if (typeof(T) == typeof(string))
            {
                result = (T)(object)value;
                validationErrorMessage = null;

                return true;
            }
            else if (typeof(T) == typeof(int) || typeof(T) == typeof(int?))
            {
                if (typeof(T) == typeof(int?) && value == null)
                {
                    result = (T)(object)null;
                }
                else
                {
                    int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var parsedValue);
                    result = (T)(object)parsedValue;
                }
                validationErrorMessage = null;

                return true;
            }
            else if (typeof(T) == typeof(short) || typeof(T) == typeof(short?))
            {
                if (typeof(T) == typeof(short?) && value == null)
                {
                    result = (T)(object)null;
                }
                else
                {
                    short.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var parsedValue);
                    result = (T)(object)parsedValue;
                }
                validationErrorMessage = null;

                return true;
            }
            else if (typeof(T) == typeof(byte) || typeof(T) == typeof(byte?))
            {
                if (typeof(T) == typeof(byte?) && value == null)
                {
                    result = (T)(object)null;
                }
                else
                {
                    byte.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var parsedValue);
                    result = (T)(object)parsedValue;
                }
                validationErrorMessage = null;

                return true;
            }
            else if (typeof(T) == typeof(bool) || typeof(T) == typeof(bool?))
            {
                if (typeof(T) == typeof(bool?) && value == null)
                {
                    result = (T)(object)null;
                }
                else
                {
                    bool.TryParse(value, out var parsedValue);
                    result = (T)(object)parsedValue;
                }
                validationErrorMessage = null;

                return true;
            }
            else if (typeof(T) == typeof(DateTime) || typeof(T) == typeof(DateTime?))
            {
                if (typeof(T) == typeof(DateTime?) && value == null)
                {
                    result = (T)(object)null;
                }
                else
                {
                    // Unwrap nullable types. We don't have to deal with receiving empty values for nullable
                    // types here, because the underlying InputBase already covers that.
                    var targetType = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);

                    bool success=false;
                    if (targetType == typeof(DateTime) || targetType == typeof(DateTime?))
                    {
                        success = BindConverter.TryConvertToDateTime(value, CultureInfo.InvariantCulture, DateFormat, out var parsedValue);
                        if (success)
                        {
                            result = (T)(object)parsedValue;
                        }
                        else
                        {
                            result = default;
                        }
                    }
                    else if (targetType == typeof(DateTimeOffset))
                    {
                        success = BindConverter.TryConvertToDateTimeOffset(value, CultureInfo.InvariantCulture, DateFormat, out var parsedValue);
                        if (success)
                        {
                            result = (T)(object)parsedValue;
                        }
                        else
                        {
                            result = default;
                        }
                    }
                    else
                    {
                        result = (T)(object)null;
                        validationErrorMessage = string.Format($"The type '{targetType}' is not a supported date type.", FieldIdentifier.FieldName);
                    }

                    if (success)
                    {
                        validationErrorMessage = null;
                        return true;
                    }
                    else
                    {
                        validationErrorMessage = string.Format($"The type '{targetType}' is not a supported date type.", FieldIdentifier.FieldName);
                        return false;
                    }
                }
                validationErrorMessage = null;
                return true;
            }
            else if (typeof(T) == typeof(Guid))
            {
                Guid.TryParse(value, out var parsedValue);
                result = (T)(object)parsedValue;
                validationErrorMessage = null;

                return true;
            }
            else if (typeof(T).IsEnum)
            {
                // There's no non-generic Enum.TryParse (https://github.com/dotnet/corefx/issues/692)
                try
                {
                    result = (T)Enum.Parse(typeof(T), value);
                    validationErrorMessage = null;

                    return true;
                }
                catch (ArgumentException)
                {
                    result = default;
                    validationErrorMessage = $"The {FieldIdentifier.FieldName} field is not valid.";

                    return false;
                }
            }

            throw new InvalidOperationException($"{GetType()} does not support the type '{typeof(T)}'.");
        }

	
	}
}
