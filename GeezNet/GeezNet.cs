using GeezNet.Convertor;

namespace GeezNet;

public class Geez
{
    private readonly GeezConvertor geezConvertor;
    private readonly AsciiConvertor asciiConvertor;

    public Geez(GeezConvertor geezConvertor, AsciiConvertor asciiConvertor)
    {
        this.geezConvertor = geezConvertor;
        this.asciiConvertor = asciiConvertor;
    }

    public static Geez Create()
    {
        return new Geez(new GeezConvertor(), new AsciiConvertor());
    }

    public string ToGeez(int asciiNumber)
    {
        return geezConvertor.Convert(asciiNumber.ToString());
    }

    public int ToAscii(string geezNumber)
    {
        return asciiConvertor.Convert(geezNumber);
    }

    public GeezConvertor GetGeezConverter()
    {
        return geezConvertor;
    }

    public AsciiConvertor GetAsciiConvertor()
    {
        return asciiConvertor;
    }
}

