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
        // catch all Exception in pipe.
        try
        {
            await next(contect);
        }
        catch (Exception ex)
        {
            // write a message to the console
            Console.WriteLine(ex.ToString());
        }
    })
    .Use(async (contect, next) =>
    {
        // TODO: Open File Log
        try
        {
            await next(contect);
        }
        finally
        {
            // TODO: Close File Log
        }
    })
    .Run(async (context) =>
    {
        await Task.Delay(100);
    });

// Create Hardware Test Pipe Line
var pipleLine = pipeBuilder.Build();

// Invoke Hardware Test Pipe Line
Console.WriteLine("Start");
await pipleLine.Invoke(null);
Console.WriteLine("End");

