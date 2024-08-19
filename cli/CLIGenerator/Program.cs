using System.CommandLine;
using CLIGenerator;

var moduleOption = new Option<string>("--module", "module name");
var nameOption = new Option<string>("--name", "Entity name");
var rootCommand = new RootCommand { moduleOption, nameOption };
var generateTemplate = new GenerateTemplate();

rootCommand.SetHandler(async (moduleOptionValue, nameOptionValue) =>
                       {
                           await generateTemplate.GenerateComponentAsync(moduleOptionValue, nameOptionValue);
                       },
                       moduleOption,
                       nameOption);

await rootCommand.InvokeAsync(args);