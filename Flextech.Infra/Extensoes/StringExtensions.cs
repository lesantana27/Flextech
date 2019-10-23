/*
==================================================================================
Solução..........: Flextech
Projeto..........: Infra
Arquivo..........: Extensoes\StringExtensions.cs
Espaço de nome...: Flextech.Infra.Extensoes
Classe...........: StringExtensions
Descrição........: Extensões da String
==================================================================================
Criação..........: 11/01/2018 - Lessandro Santana
Alteração........: 29/05/2019 - Lessandro Santana
==================================================================================
*/

using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace Flextech.Infra.Extensoes
{
    public static class StringExtensions
    {
        // Convert the string to Pascal case.
        public static string ToPascalCase(this string str)
        {
            TextInfo info = Thread.CurrentThread.CurrentCulture.TextInfo;
            str = info.ToTitleCase(str);
            string[] parts = str.Split(new char[] { },
                StringSplitOptions.RemoveEmptyEntries);
            string result = string.Join(string.Empty, parts);
            return result;
        }

        // Convert the string to camel case.
        public static string ToCamelCase(this string str)
        {
            str = str.ToPascalCase();
            return str.Substring(0, 1).ToLower() + str.Substring(1);
        }

        // Capitalize the first character and add a space before
        // each capitalized letter (except the first character).
        public static string ToProperCase(this string str)
        {
            const string pattern = @"(?<=\w)(?=[A-Z])";
            //const string pattern = @"(?<=[^A-Z])(?=[A-Z])";
            string result = Regex.Replace(str, pattern, " ", RegexOptions.None);
            return result.Substring(0, 1).ToUpper() + result.Substring(1);
        }

        public static string ToParcialSize(this string str)
        {
            return ToParcialSize(str, 40);
        }

        public static string ToParcialSize(this string str, int size)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(str);

            for (int i = 0; i < size; i++)
            {
                sb.Append(" ");
            }

            return sb.ToString().Substring(0, size).Trim() + "...";
        }

        public static string RemoveAccent(this string str)
        {
            string withAccent = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç";
            string withoutAccent = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc";

            for (int i = 0; i < withAccent.Length; i++)
            {
                str = str.Replace(withAccent[i].ToString(), withoutAccent[i].ToString());
            }

            return str;
        }

        public static string OnlyNumbers(this string str)
        {
            return new System.String(str.Where(char.IsDigit).ToArray());
        }




        public static DateTime ToDateTime(this string str, FormatoDataHora format)
        {
            string value = str.OnlyNumbers();
            switch (format)
            {
                case FormatoDataHora.ddMMyyyyHHmmss:
                    if (value.Length != 14) { break; }
                    return new DateTime(Convert.ToInt32(value.Substring(4, 4)), Convert.ToInt32(value.Substring(2, 2)), Convert.ToInt32(value.Substring(0, 2)), Convert.ToInt32(value.Substring(8, 2)), Convert.ToInt32(value.Substring(10, 2)), Convert.ToInt32(value.Substring(12, 2)));
                default:
                    break;
            }

            return new DateTime();
        }

        public static DateTime ToDateTime(this string str, FormatoDataHora from, FormatoDataHora to)
        {
            string value = str.OnlyNumbers();

            DateTime d = DateTime.Now;


            if (from == FormatoDataHora.ddMMyyyyHHmmss && to == FormatoDataHora.yyyyMMddHHmmss)
            {
                if (DateTime.TryParse(str, out d)) return d;

                // 01 01 2019 00 00 00
                // 01 23 4567 89 01 23
                return new DateTime(Convert.ToInt32(value.Substring(4, 4)), Convert.ToInt32(value.Substring(2, 2)), Convert.ToInt32(value.Substring(0, 2)), Convert.ToInt32(value.Substring(8, 2)), Convert.ToInt32(value.Substring(10, 2)), Convert.ToInt32(value.Substring(12, 2)));
            }

            if (from == FormatoDataHora.yyyyMMdd && to == FormatoDataHora.yyyyMMddHHmmss)
            {
                if (DateTime.TryParse(str, out d)) return d;

                // 2019 09 27
                // 0123 45 67
                return new DateTime(Convert.ToInt32(value.Substring(0, 4)), Convert.ToInt32(value.Substring(4, 2)), Convert.ToInt32(value.Substring(6, 2)), 0, 0, 0);
            }

            return new DateTime();
        }

        public static int TryParseToInt(this string value)
        {
            int valueInt = 0;
            int.TryParse(value, out valueInt);

            return valueInt;
        }

        public static bool ToBoolean(this string value)
        {
            if (string.IsNullOrEmpty(value)) return false;

            if (value.ToLower() == "on") return true;
            if (value.ToLower() == "true") return true;

            return false;
        }

        public static Guid ToGuid(this string value)
        {
            return new Guid(value);
        }

        public static decimal TryParseToDecimal(this string value)
        {
            if (string.IsNullOrEmpty(value)) return 0;

            value = value.Replace(".", ",");

            decimal valueDecimal = 0;
            decimal.TryParse(value, out valueDecimal);

            return valueDecimal;
        }

    }



}
