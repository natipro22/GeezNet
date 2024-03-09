using System;
using GeezNet.Exceptions;

namespace GeezNet.Convertor;
public class GeezConvertor : Convertor
{
    public string Convert(string asciiNumber)
    {
        string number = PrepareForConversion(asciiNumber);
        int length = number.Length;
        string result = EMPTY_CHARACTER;

        for (int index = 0; index < length; index += 2)
        {
            result += ParseEachTwoCharactersBlock(number, index, length);
        }

        return result;
    }

    private string PrepareForConversion(string asciiNumber)
    {
        string validatedNumber = ValidateAsciiNumber(asciiNumber).ToString();
        int length = validatedNumber.Length;
        string number = PrependSpaceIfLengthIsEven(validatedNumber, length);

        return number;
    }

    private int ValidateAsciiNumber(string asciiNumber)
    {
        if (!int.TryParse(asciiNumber, out int number) || number < 1)
        {
            throw new NotAnIntegerArgumentException(asciiNumber);
        }

        return number;
    }

    private string PrependSpaceIfLengthIsEven(string asciiNumber, int length)
    {
        if (IsOdd(length))
        {
            return " " + asciiNumber;
        }

        return asciiNumber;
    }

    private bool IsOdd(int number)
    {
        return !IsEven(number);
    }

    private bool IsEven(int number)
    {
        return number % 2 == 0;
    }

    private string ParseEachTwoCharactersBlock(string number, int index, int length)
    {
        string geezNumber = GetGeezNumberOfTheBlock(number, index);
        int bet = GetBet(length, index);
        string geezSeparator = GetGeezSeparator(bet);

        return CombineBlockAndSeparator(geezNumber, geezSeparator, index);
    }

    private string GetGeezNumberOfTheBlock(string number, int index)
    {
        string block = GetBlock(number, index);
        int tenth = block.Length > 0 && block[0] != ' ' ? int.Parse(block[0].ToString()) : 0;
        int once = int.Parse(block[block.Length - 1].ToString());

        return GEEZ_NUMBERS[tenth * 10] + GEEZ_NUMBERS[once];
    }

    private string GetBlock(string number, int index)
    {
        return number.Substring(index, Math.Min(2, number.Length - index));
    }

    private int GetBet(int length, int index)
    {
        int reverseIndex = length - 1 - index;
        return reverseIndex / 2;
    }

    private string GetGeezSeparator(int bet)
    {
        if (IsZero(bet))
        {
            return EMPTY_CHARACTER;
        }
        if (IsOdd(bet))
        {
            return GEEZ_NUMBERS[100];
        }

        return GEEZ_NUMBERS[10000];
    }

    private string CombineBlockAndSeparator(string geezNumber, string separator, int index)
    {
        if (ShouldRemoveGeezSeparator(geezNumber, separator))
        {
            separator = EMPTY_CHARACTER;
        }

        if (ShouldRemoveGeezNumberBlock(geezNumber, separator, index))
        {
            geezNumber = EMPTY_CHARACTER;
        }

        return geezNumber + separator;
    }

    private bool ShouldRemoveGeezSeparator(string block, string separator)
    {
        return string.IsNullOrWhiteSpace(block) && separator == GEEZ_NUMBERS[100];
    }

    private bool ShouldRemoveGeezNumberBlock(string block, string separator, int index)
    {
        return (IsOneHundred(block, separator) || IsLeadingTenThousand(block, separator, index));
    }

    private bool IsOneHundred(string block, string separator)
    {
        return separator == GEEZ_NUMBERS[100] && block == GEEZ_NUMBERS[1];
    }

    private bool IsLeadingTenThousand(string block, string separator, int index)
    {
        return index == 0 && block == GEEZ_NUMBERS[1] && separator == GEEZ_NUMBERS[10000];
    }
}

