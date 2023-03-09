using Microsoft.Extensions.DependencyInjection;
using Shinus9008.NetHTF.Workspace.Testing;

// Create Service Collection
ServiceCollection services = new ServiceCollection();

// Create Hardware Test Pipe Line Builder
var pipeBuilder = new HardwareTestBuilder(services.BuildServiceProvider());

// Configure Hardware Test Pipe Line
pipeBuilder
    .Use(async (contect, next) =>
    {
        Console.WriteLine("Pipe:1 -->");
        await Task.Delay(100);
        await next(contect);
        Console.WriteLine("Pipe:1 <--");
    })
    .Use(async (contect, next) =>
    {
        Console.WriteLine("Pipe:2 -->");
        await Task.Delay(100);
        await next(contect);
        Console.WriteLine("Pipe:2 <--");
    })
    .Run(async (context) =>
    {
        Console.WriteLine("End, go back");
        await Task.Delay(100);
    });

// Create Hardware Test Pipe Line
var pipleLine = pipeBuilder.Build();

// Invoke Hardware Test Pipe Line
Console.WriteLine("Start");
await pipleLine.Invoke(null);
Console.WriteLine("End");

