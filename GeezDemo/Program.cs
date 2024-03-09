using System.Text;
using GeezNet;
Console.OutputEncoding = Encoding.UTF8;
var geez = Geez.Create();
Console.WriteLine(geez.ToGeez(123));              // ፻፳፫
Console.WriteLine(geez.ToGeez(1234));             // ፲፪፻፴፬
Console.WriteLine(geez.ToGeez(1986));             // ፲፱፻፹፮
Console.WriteLine(geez.ToGeez(1000000));          // ፻፼

// or you can even do the reverse
// this is the tricky part you wouldn't see else where
// at least for now

Console.WriteLine(geez.ToAscii("፻፳፫"));           // 123
Console.WriteLine(geez.ToAscii("፲፪፻፴፬"));         // 1234
Console.WriteLine(geez.ToAscii("፲፱፻፹፮"));        // 1986
Console.WriteLine(geez.ToAscii("፻፼"));
