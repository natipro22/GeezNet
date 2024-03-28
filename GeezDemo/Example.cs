using GeezNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeezDemo;
public class Example(IGeez geez)
{
    private readonly IGeez _geez = geez;

    public void Show()
    {
        Console.WriteLine("ASCII to Geez");
        Console.WriteLine($"123 -> {_geez.ToGeez(123)}");              // ፻፳፫
        Console.WriteLine($"1234 -> {_geez.ToGeez(1234)}");             // ፲፪፻፴፬
        Console.WriteLine($"1888 -> {_geez.ToGeez(1888)}");             // ፲፱፻፹፮
        Console.WriteLine($"1000000 -> {_geez.ToGeez(1000000)}");          // ፻፼

        // or you can even do the reverse
        // this is the tricky part you wouldn't see else where
        // at least for now
        Console.WriteLine();
        Console.WriteLine("Geez to ASCII");
        Console.WriteLine($"፻፳፫ -> {_geez.ToAscii("፻፳፫")}");           // 123
        Console.WriteLine($"፲፪፻፴፬ -> {_geez.ToAscii("፲፪፻፴፬")}");         // 1234
        Console.WriteLine($"፲፰፻፹፰ -> {_geez.ToAscii("፲፰፻፹፰")}");        // 1888
        Console.WriteLine($"፻፼ -> {_geez.ToAscii("፻፼")}");          // 1000000
    }
}
