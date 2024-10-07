﻿using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Kitchen.Application.Utils;

public class StringUtils
{
    public static string FormatName(string? inputName)
    {
        if (string.IsNullOrWhiteSpace(inputName))
        {
            return string.Empty;
        }

        var words = inputName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var cultureInfo = CultureInfo.CurrentCulture;

        var formattedName = new StringBuilder();

        for (var i = 0; i < words.Length; i++)
        {
            var currentWord = words[i].ToLower(cultureInfo);
            formattedName.Append(char.ToUpper(currentWord[0], cultureInfo))
                .Append(currentWord.AsSpan(1));

            if (i < words.Length - 1)
            {
                formattedName.Append(' ');
            }
        }

        return formattedName.ToString();
    }

    public static string GenerateRandomNumber(int length)
    {
        const string chars = "0123456789";
        Random random = new Random();
        StringBuilder stringBuilder = new StringBuilder(length);

        for (int i = 0; i < length; i++)
        {
            stringBuilder.Append(chars[random.Next(chars.Length)]);
        }

        return stringBuilder.ToString();
    }

    public static string GenerateRandomNumberString(int length)
    {
        //const string chars = "0123456789";
        const string chars = "qwertyuiioplkjhgfdsazxcvbnm0123456789";
        Random random = new Random();
        StringBuilder stringBuilder = new StringBuilder(length);

        for (int i = 0; i < length; i++)
        {
            stringBuilder.Append(chars[random.Next(chars.Length)]);
        }

        return stringBuilder.ToString();
    }

    public static int GetMomoId(string id)
    {
        Regex regex = new Regex("-(\\d+)");
        var macth = regex.Match(id);
        if (macth.Success) return Int32.Parse(macth.Groups[1].Value);
        return 0;
    }
}