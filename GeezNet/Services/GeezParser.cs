using GeezNet.Exceptions;
using System.Linq;

namespace GeezNet.Services;

public class GeezParser
{
    private string geezNumber;
    private List<(int block, int separator)> parsed;

    public GeezParser(string geezNumber)
    {
        SetGeezNumber(geezNumber);
        parsed = null;
    }

    public void SetGeezNumber(string geezNumber)
    {
        if (string.IsNullOrEmpty(geezNumber))
        {
            throw new NotGeezArgumentException("Geez number cannot be null or empty.");
        }

        this.geezNumber = geezNumber;
    }

    public Queue<(int block, int separator)> GetParsed()
    {
        return new Queue<(int block, int separator)>(parsed);
    }

    public void Parse()
    {
        parsed = new List<(int block, int separator)>();

        int block = 0;
        int length = geezNumber.Length;

        for (int index = 0; index < length; index++)
        {
            block = ParseCharacter(index, block);
        }

        PushToQueue(block, 1);
    }

    private int ParseCharacter(int index, int block)
    {
        int asciiNumber = ParseGeezAtIndex(index);

        if (IsNotGeezSeparator(asciiNumber))
        {
            block += asciiNumber;
        }
        else
        {
            PushToQueue(block, asciiNumber);
            block = 0;
        }

        return block;
    }

    private int ParseGeezAtIndex(int index)
    {
        char geezChar = geezNumber[index];
        return GetAsciiNumber(geezChar);
    }

    private int GetAsciiNumber(char geezChar)
    {

        Dictionary<int, string> GEEZ_NUMBERS = Convertor.Convertor.GEEZ_NUMBERS;
        if (!GEEZ_NUMBERS.ContainsValue(geezChar.ToString()))
        {
            throw new NotGeezArgumentException($"'{geezChar}' is not a valid geez character.");
        }

        foreach (var pair in from pair in GEEZ_NUMBERS
                             where pair.Value == geezChar.ToString()
                             select pair)
        {
            return pair.Key;
        }

        throw new NotGeezArgumentException($"Failed to get the ASCII number for geez character '{geezChar}'.");
    }

    private bool IsNotGeezSeparator(int asciiNumber)
    {
        return asciiNumber < 100;
    }

    private void PushToQueue(int block, int separator)
    {
        parsed.Add((block, separator));
    }
}

