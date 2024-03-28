using System.Text;
using GeezDemo;
using GeezNet;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
Console.OutputEncoding = Encoding.UTF8;
HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddGeezNet();
builder.Services.AddTransient<Example>();

using IHost host = builder.Build();

var examples = host.Services.GetRequiredService<Example>();
examples.Show();

await host.RunAsync();


