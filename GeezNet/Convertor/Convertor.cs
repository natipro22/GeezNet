using System.Collections.Generic;

namespace GeezNet.Convertor;

public class Convertor
{
    // Constants
    protected const string EMPTY_CHARACTER = "";

    public static readonly Dictionary<int, string> GEEZ_NUMBERS = new Dictionary<int, string>
    {
        { 0, "" },
        { 1, "፩" },
        { 2, "፪" },
        { 3, "፫" },
        { 4, "፬" },
        { 5, "፭" },
        { 6, "፮" },
        { 7, "፯" },
        { 8, "፰" },
        { 9, "፱" },
        { 10, "፲" },
        { 20, "፳" },
        { 30, "፴" },
        { 40, "፵" },
        { 50, "፶" },
        { 60, "፷" },
        { 70, "፸" },
        { 80, "፹" },
        { 90, "፺" },
        { 100, "፻" },
        { 10000, "፼" }
    };

    // Properties
    public string EmptyCharacter { get { return EMPTY_CHARACTER; } }

    public Dictionary<int, string> GeezNumbers { get { return GEEZ_NUMBERS; } }

    // Methods
    public bool IsZero(int number)
    {
        return number == 0;
    }

    public bool IsGeezNumber(int geezNumber, int number)
    {
        return GeezNumbers.ContainsKey(number) && GeezNumbers[number] == geezNumber.ToString();
    }

    public bool IsGeezNumberHundred(int geezNumber)
    {
        return IsGeezNumber(geezNumber, 100);
    }

    public bool IsGeezNumberOne(int geezNumber)
    {
        return IsGeezNumber(geezNumber, 1);
    }

    public bool IsGeezNumberTenThousand(int geezNumber)
    {
        return IsGeezNumber(geezNumber, 10000);
    }
}

