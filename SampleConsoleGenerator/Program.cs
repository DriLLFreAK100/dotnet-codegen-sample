using CodeGenerator;
using CodeGenerator.Models;
using SampleConsoleGenerator;
using System.Reflection;
using System.Text.Json;

TypeScript generator = new (new Option()
{
    IsDryRun = false,
    RelativeBaseOutputPath="../../../GeneratedOutputs",
    TargetAssemblies = new()
    {
        Assembly.GetAssembly(typeof(InterfaceRoot)),
    }
});

var outputs = generator.Generate();

Console.WriteLine(JsonSerializer.Serialize(outputs, new JsonSerializerOptions()
{
    WriteIndented = true,
}));

Console.Read();