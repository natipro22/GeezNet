# GeezNet
GeezNet is a .NET library designed to facilitate the conversion between ASCII numbers and Geez numbers, and vice versa. The library provides functionality to convert numeric values represented in ASCII format (e.g., '1234') to their corresponding Geez representation (e.g., '፲፪፻፴፬'), and conversely, it can convert Geez numbers to their ASCII equivalents.
> Ge'ez (ግዕዝ) is an ancient South Semitic language that originated in Eritrea and
> the northern region of Ethiopia in the Horn of Africa. It later became the
> official language of the Kingdom of Aksum and Ethiopian imperial court.
> [read more](https://en.wikipedia.org/wiki/Ge%27ez).

## Features:

+ Conversion Functionality: GeezNet offers robust conversion capabilities, allowing users to seamlessly convert numeric values between ASCII and Geez representations. 
+ Support for Geez Language: GeezNet is tailored specifically for the Geez language, an ancient South Semitic language primarily used in Eritrea and Ethiopia. It embraces the unique characters and numerical representations of the Geez script.
+ Ease of Integration: The library is easy to integrate into .NET projects, offering straightforward installation and usage.
+ Bi-Directional Conversion: GeezNet facilitates bidirectional conversion, enabling users to convert from ASCII to Geez and vice versa effortlessly.

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
builder.Services.AddGeezNet();

using IHost host = builder.Build();

var geez = host.Services.GetRequiredService<IGeez>();

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
