using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeezNet.Services;


namespace GeezNet.Convertor;

public class AsciiConvertor : Convertor, IAsciiConvertor
{
    public int Convert(string geezNumber)
    {
        Queue<(int block, int separator)> parsed = Parse(geezNumber);
        return Calculate(parsed);
    }

    private Queue<(int block, int separator)> Parse(string geezNumber)
    {
        GeezParser parser = new GeezParser(geezNumber);
        parser.Parse();
        return parser.GetParsed();
    }

    private int Calculate(Queue<(int block, int separator)> parsed)
    {
        GeezCalculator calculator = new GeezCalculator(parsed);
        calculator.Calculate();
        return calculator.GetCalculated();
    }
}

