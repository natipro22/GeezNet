using GeezNet.Convertor;

namespace GeezNet;

public class Geez : IGeez
{
    private readonly IGeezConvertor _geezConvertor;
    private readonly IAsciiConvertor _asciiConvertor;

    public Geez(IGeezConvertor geezConvertor, IAsciiConvertor asciiConvertor)
    {
        this._geezConvertor = geezConvertor;
        this._asciiConvertor = asciiConvertor;
    }

    public string ToGeez(int asciiNumber)
    {
        return _geezConvertor.Convert(asciiNumber.ToString());
    }

    public int ToAscii(string geezNumber)
    {
        return _asciiConvertor.Convert(geezNumber);
    }
}

