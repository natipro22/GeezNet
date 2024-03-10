# GeezNet
library to convert ascii number like '3456' to geez number '፴፬፻፶፮' and vise versa.
> Ge'ez (ግዕዝ) is an ancient South Semitic language that originated in Eritrea and
> the northern region of Ethiopia in the Horn of Africa. It later became the
> official language of the Kingdom of Aksum and Ethiopian imperial court.
> [read more](https://en.wikipedia.org/wiki/Ge%27ez).

## Insatllation
### Package Manager
``` 
Insatall-Package GeezNet
```
### CLI
``` 
dotnet add package GeezNet
```

## Usage
```C#
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
```
