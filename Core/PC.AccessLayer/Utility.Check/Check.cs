﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC.AccessLayer.Utility.Check
{
    internal class Check
    {
        internal Check()
        {
        }

        public class Argument
        {
            internal Argument()
            {
            }

            public static void IsNotEmpty(DateTime argument, string argumentName)
            {
                if (argument == DateTime.MinValue)
                {
                    throw new ArgumentException("\"{0}\" cannot be datetime minimum valu.".FormatWith(argumentName), argumentName);
                }
            }

            public static void IsNotEmpty(Guid argument, string argumentName)
            {
                if (argument == Guid.Empty)
                {
                    throw new ArgumentException("\"{0}\" cannot be empty guid.".FormatWith(argumentName), argumentName);
                }
            }

            public static void IsNotEmpty(Enum argument, Enum emptyValue, string argumentName)
            {
                if (argument == emptyValue)
                {
                    throw new ArgumentException("\"{0}\" cannot be \"{1}\".".FormatWith(argumentName, emptyValue), argumentName);
                }
            }

            public static void IsNotEmpty(string argument, string argumentName)
            {
                if (string.IsNullOrEmpty((argument ?? string.Empty).Trim()))
                {
                    throw new ArgumentException("\"{0}\" cannot be blank.".FormatWith(argumentName), argumentName);
                }
            }

            public static void IsNotEmptyOrWhitespace(string argument, string argumentName)
            {
                if (string.IsNullOrWhiteSpace(argument))
                {
                    throw new ArgumentException("\"{0}\" cannot be blank.".FormatWith(argumentName), argumentName);
                }
            }

            public static void IsNotOutOfLength(string argument, int length, string argumentName)
            {
                if (argument.Trim().Length > length)
                {
                    throw new ArgumentException("\"{0}\" cannot be more than {1} character.".FormatWith(argumentName, length), argumentName);
                }
            }

            public static void IsNotNull(object argument, string argumentName)
            {
                if (argument == null)
                {
                    throw new ArgumentNullException(argumentName);
                }
            }

            public static void IsNotNull(int? argument, string argumentName)
            {
                if (argument == null)
                {
                    throw new ArgumentNullException(argumentName);
                }
                Check.Argument.IsNotNegativeOrZero(argument.Value, argumentName);
            }

            public static void IsNotNullZero(int? argument, string argumentName)
            {
                if (argument == null)
                {
                    throw new ArgumentNullException(argumentName);
                }
                Check.Argument.IsNotNegative(argument.Value, argumentName);
            }


            public static void IsNumericString(string argument, string argumentName)
            {
                long n;
                bool isNumeric = long.TryParse(argument, out n);
                if (isNumeric == false)
                {
                    throw new ArgumentException(argumentName + "is not a number.");
                }
            }

            public static bool IsNumericStringReturn(string argument)
            {
                long n;
                bool isNumeric = long.TryParse(argument, out n);
                if (isNumeric == false)
                    return false;
                else
                    return true;
            }

            public static void IsGreaterThanCurrentDate(DateTime argument, string argumentName)
            {

                if (!(argument > DateTime.Now))
                {
                    throw new ArgumentException(argumentName + " should be greater than current date.");
                }
            }

            public static void IsNotNegative(int? argument, string argumentName)
            {
                IsNotNull(argument, argumentName);
                if (argument < 0)
                {
                    throw new ArgumentOutOfRangeException(argumentName);
                }
            }

            public static void IsNotNegative(int argument, string argumentName)
            {
                if (argument < 0)
                {
                    throw new ArgumentOutOfRangeException(argumentName);
                }
            }

            public static void IsNotNegativeOrZero(int argument, string argumentName)
            {
                if (argument <= 0)
                {
                    throw new ArgumentOutOfRangeException(argumentName);
                }
            }

            public static void IsNotNegativeOrZero(int? argument, string argumentName)
            {
                IsNotNull(argument, argumentName);
                if (argument <= 0)
                {
                    throw new ArgumentOutOfRangeException(argumentName);
                }
            }

            public static void IsNotNegative(long argument, string argumentName)
            {
                if (argument < 0)
                {
                    throw new ArgumentOutOfRangeException(argumentName);
                }
            }

            public static void IsNotNegativeOrZero(long argument, string argumentName)
            {
                if (argument <= 0)
                {
                    throw new ArgumentOutOfRangeException(argumentName);
                }
            }

            public static void IsNotNegative(float argument, string argumentName)
            {
                if (argument < 0)
                {
                    throw new ArgumentOutOfRangeException(argumentName);
                }
            }

            public static void IsNotNegativeOrZero(float argument, string argumentName)
            {
                if (argument <= 0)
                {
                    throw new ArgumentOutOfRangeException(argumentName);
                }
            }

            public static void IsNotNegative(decimal argument, string argumentName)
            {
                if (argument < 0)
                {
                    throw new ArgumentOutOfRangeException(argumentName);
                }
            }

            public static void IsNotNegative(decimal? argument, string argumentName)
            {
                IsNotNull(argument, argumentName);
                if (argument < 0)
                {
                    throw new ArgumentOutOfRangeException(argumentName);
                }
            }

            public static void IsNotNegativeOrZero(decimal argument, string argumentName)
            {
                if (argument <= 0)
                {
                    throw new ArgumentOutOfRangeException(argumentName);
                }
            }

            public static void IsNotNegativeOrZero(decimal? argument, string argumentName)
            {
                IsNotNull(argument, argumentName);
                if (argument <= 0)
                {
                    throw new ArgumentOutOfRangeException(argumentName);
                }
            }

            public static void IsNotInvalidDate(DateTime argument, string argumentName)
            {
                if (!(argument >= DateTime.MinValue) && (argument <= DateTime.MaxValue))
                {
                    throw new ArgumentOutOfRangeException(argumentName);
                }
            }

            public static void IsNotInvalidDate(DateTime? argument, string argumentName)
            {
                IsNotNull(argument, argumentName);
                if (!(argument >= DateTime.MinValue) && (argument <= DateTime.MaxValue))
                {
                    throw new ArgumentOutOfRangeException(argumentName);
                }
            }

            public static void IsNotInPast(DateTime? argument, string argumentName)
            {
                IsNotNull(argument, argumentName);
                if (argument < DateTime.Now)
                {
                    throw new ArgumentOutOfRangeException(argumentName);
                }
            }

            public static void IsNotInPast(DateTime argument, string argumentName)
            {
                if (argument < DateTime.Now)
                {
                    throw new ArgumentOutOfRangeException(argumentName);
                }
            }

            public static void IsNotInFuture(DateTime argument, string argumentName)
            {
                if (argument > DateTime.Now)
                {
                    throw new ArgumentOutOfRangeException(argumentName);
                }
            }

            public static void IsNotNegative(TimeSpan argument, string argumentName)
            {
                if (argument < TimeSpan.Zero)
                {
                    throw new ArgumentOutOfRangeException(argumentName);
                }
            }

            public static void IsNotNegativeOrZero(TimeSpan argument, string argumentName)
            {
                if (argument <= TimeSpan.Zero)
                {
                    throw new ArgumentOutOfRangeException(argumentName);
                }
            }

            public static void IsNotEmpty<T>(ICollection<T> argument, string argumentName)
            {
                IsNotNull(argument, argumentName);

                if (argument.Count == 0)
                {
                    throw new ArgumentException("Collection cannot be empty.", argumentName);
                }
            }

            public static void IsNotOutOfRange(int argument, int min, int max, string argumentName)
            {
                if ((argument < min) || (argument > max))
                {
                    throw new ArgumentOutOfRangeException(argumentName, "{0} must be between \"{1}\"-\"{2}\".".FormatWith(argumentName, min, max));
                }
            }

            public static void IsNotInvalidEmail(string argument, string argumentName)
            {
                IsNotEmpty(argument, argumentName);

                if (!argument.IsEmail())
                {
                    throw new ArgumentException("\"{0}\" is not a valid email address.".FormatWith(argumentName), argumentName);
                }
            }

            public static void IsNotInvalidWebUrl(string argument, string argumentName)
            {
                IsNotEmpty(argument, argumentName);

                if (!argument.IsWebUrl())
                {
                    throw new ArgumentException("\"{0}\" is not a valid web url.".FormatWith(argumentName), argumentName);
                }
            }

            public static void IsEndDateGreaterThanStart(DateTime endDate, DateTime startDate, string argumentName1, string argumentName2)
            {
                if (!(endDate.Date > startDate.Date))
                {
                    throw new ArgumentException("\"{0}\" should be greater than \"{1}\"".FormatWith(argumentName1, argumentName2));
                }
            }

            public static void IsNotInvaildEnumValue(Type enumType, int value, string argumentName)
            {
                if (!Enum.IsDefined(enumType, value))
                {
                    throw new ArgumentException("\"{0}\" is not valid Enum Value".FormatWith(argumentName), argumentName);
                }
            }
        }
    }

}

