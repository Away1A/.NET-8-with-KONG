using System.Transactions;
using Newtonsoft.Json.Serialization;
using Type = CLIGenerator.Enums.Type;

namespace CLIGenerator;

public class GenerateTemplate
{
    /// <summary>
    /// Generates a component asynchronously based on the given module and name.
    /// </summary>
    /// <param name="module">The module name for the component.</param>
    /// <param name="name">The name of the component.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task GenerateComponentAsync(string module, string name)
    {
        var basePath = "../../src/Core";
        using var transactionScope = new TransactionScope();
        try
        {
            var pathRepo = Path.Combine(basePath, "Repository", $"Garuda.Repository.{module}");
            var isModuleRepoExist = Directory.Exists(pathRepo);
            if (!isModuleRepoExist)
            {
                // create repo module
                await GenerateModuleAsync(pathRepo, module, Type.Repository);
            }

            var pathService = Path.Combine(basePath, "Application", $"Garuda.Application.{module}");
            var isModuleServiceExist = Directory.Exists(pathService);
            if (!isModuleServiceExist)
            {
                // create service module
                await GenerateModuleAsync(pathService, module, Type.Service);
            }

            var pathDomain = Path.Combine(basePath, "Domain", $"Garuda.Domain.{module}");
            var isModuleDomainExist = Directory.Exists(pathDomain);
            if (!isModuleDomainExist)
            {
                // create domain module
                await GenerateModuleAsync(pathDomain, module, Type.Model);
            }

            var pathPresentation = Path.Combine("../../src", "Presentation", $"Garuda.Presentation.{module}");
            var isModulePresentationExist = Directory.Exists(pathPresentation);
            if (!isModulePresentationExist)
            {
                // create presentation module
                await GenerateModuleAsync(pathPresentation, module, Type.Controller);
            }

            var pathTemplateController = "Templates/Controller/controller.template";
            var pathToController = $"../../src/Presentation/Garuda.Presentation.{module}/Controllers/V1";
            await GenerateFileAsync(pathTemplateController, pathToController, module, name, Type.Controller);

            var pathTemplateModel = "Templates/Model/model.template";
            var pathToModel = $"{basePath}/Domain/Garuda.Domain.{module}/Models";
            await GenerateFileAsync(pathTemplateModel, pathToModel, module, name, Type.None);

            var pathTemplateSeeder = "Templates/Seeder/seeder.template";
            var pathToSeed = $"{basePath}/Domain/Garuda.Domain.{module}/Seeds";
            await GenerateFileAsync(pathTemplateSeeder, pathToSeed, module, name, Type.Seed);

            var pathTemplateIRepository = "Templates/Repository/Contract/irepository.template";
            var pathToIRepo = $"{basePath}/Repository/Garuda.Repository.{module}/Repositories/Contracts";
            await GenerateFileAsync(pathTemplateIRepository, pathToIRepo, module, name, Type.IRepository);

            var pathTemplateRepository = "Templates/Repository/repository.template";
            var pathToRepo = $"{basePath}/Repository/Garuda.Repository.{module}/Repositories";
            await GenerateFileAsync(pathTemplateRepository, pathToRepo, module, name, Type.Repository);

            var pathTemplateIService = "Templates/Service/Contract/iservice.template";
            var pathToIService = $"{basePath}/Application/Garuda.Application.{module}/Services/V1/Contracts";
            await GenerateFileAsync(pathTemplateIService, pathToIService, module, name, Type.IService);

            var pathTemplateService = "Templates/Service/service.template";
            var pathToService = $"{basePath}/Application/Garuda.Application.{module}/Services/V1";
            await GenerateFileAsync(pathTemplateService, pathToService, module, name, Type.Service);

            var pathTemplateDto = "Templates//Dto/dto.template";
            var pathToServiceDto = $"{basePath}/Application/Garuda.Application.{module}/Dto";
            await GenerateFileAsync(pathTemplateDto, pathToServiceDto, module, name, Type.Dto);

            var pathTemplateRequest = "Templates//Dto/request.template";
            var pathToServiceDtoRequest = $"{basePath}/Application/Garuda.Application.{module}/Dto/Requests";
            await GenerateFileAsync(pathTemplateRequest, pathToServiceDtoRequest, module, name, Type.Request);

            var pathTemplateResponse = "Templates//Dto/response.template";
            var pathToServiceDtoResponse = $"{basePath}/Application/Garuda.Application.{module}/Dto/Responses";
            await GenerateFileAsync(pathTemplateResponse, pathToServiceDtoResponse, module, name, Type.Response);
            transactionScope.Complete();
        }
        catch
        {
            // do nothing to rollback transaction scope.
        }
    }

    /// <summary>
    /// Generates a file asynchronously based on the given parameters.
    /// </summary>
    /// <param name="pathTemplate">The path to the template file.</param>
    /// <param name="pathOutput">The path where the generated file will be saved.</param>
    /// <param name="module">The module name for the file.</param>
    /// <param name="name">The name of the file.</param>
    /// <param name="type">The type of the file.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    private async Task GenerateFileAsync(string pathTemplate, string pathOutput, string module, string name, Type type)
    {
        var output = await PopulateTemplateAsync(pathTemplate, module, name);
        switch (type)
        {
            case Type.Controller:
            case Type.Service:
            case Type.Repository:
            case Type.Request:
            case Type.Dto:
            case Type.Response:
                pathOutput = Path.Combine(pathOutput, $"{name}{type}.cs");
                break;
            case Type.IService:
                pathOutput = Path.Combine(pathOutput, $"I{name}Service.cs");
                break;
            case Type.IRepository:
                pathOutput = Path.Combine(pathOutput, $"I{name}Repository.cs");
                break;
            case Type.None:
                pathOutput = Path.Combine(pathOutput, $"{name}.cs");
                break;
            case Type.Module:
            case Type.Model:
            case Type.Seed:
            default:
                return;
        }

        if (Directory.Exists(pathOutput))
        {
            return;
        }

        if (File.Exists(pathOutput))
        {
            return;
        }

        await WriteToFileAsync(pathOutput, output);
    }

    /// <summary>
    /// Generates a module asynchronously based on the given parameters.
    /// </summary>
    /// <param name="modulePath">The path where the module will be generated.</param>
    /// <param name="module">The module name.</param>
    /// <param name="type">The type of the module.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    /// <exception cref="System.IO.DirectoryNotFoundException">Thrown if the directory for the module path does not exist.</exception>
    private async Task GenerateModuleAsync(string modulePath, string module, Type type)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(modulePath) ?? string.Empty);

        switch (type)
        {
            case Type.Controller:
                var csProjControllerTemplate = "Templates/controller-csproj.template";
                var csProjControllerOutput = Path.Combine(modulePath, $"Garuda.Presentation.{module}.csproj");

                await File.WriteAllTextAsync(csProjControllerOutput,
                                             await PopulateTemplateAsync(csProjControllerTemplate,
                                                                         module,
                                                                         string.Empty));
                break;
            case Type.Repository:
                var csProjRepositorTemplate = "Templates/repositories-csproj.template";
                var csProjRepositryOutput = Path.Combine(csProjRepositorTemplate, $"Garuda.Repository.{module}.csproj");

                await File.WriteAllTextAsync(csProjRepositryOutput,
                                             await PopulateTemplateAsync(csProjRepositorTemplate,
                                                                         module,
                                                                         string.Empty));
                break;
            case Type.Service:
                var csProjApplicationTemplate = "Templates/domain-controller.template";
                var csProjApplicationOutput =
                    Path.Combine(csProjApplicationTemplate, $"Garuda.Application.{module}.csproj");

                await File.WriteAllTextAsync(csProjApplicationOutput,
                                             await PopulateTemplateAsync(csProjApplicationTemplate,
                                                                         module,
                                                                         string.Empty));
                break;
            case Type.Model:
                var csProjDomainTemplate = "Templates/domain-controller.template";
                var csProjDomainOutput = Path.Combine(csProjDomainTemplate, $"Garuda.Domain.{module}.csproj");

                await File.WriteAllTextAsync(csProjDomainOutput,
                                             await PopulateTemplateAsync(csProjDomainTemplate, module, string.Empty));
                break;
            default:
                return;
        }

        // create Actions Folder
        var actionTemplate = "Templates/Actions/actions.template";
        var actionFolderOutput = Path.Combine(modulePath, "Actions", $"Add{module}Actions.cs");
        await WriteToFileAsync(actionFolderOutput, await PopulateTemplateAsync(actionTemplate, module, string.Empty));
    }

    /// <summary>
    /// Writes the output template to a file asynchronously at the specified output path.
    /// </summary>
    /// <param name="outputPath">The path where the file will be saved.</param>
    /// <param name="outputTemplate">The content of the file template to be written.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    private Task WriteToFileAsync(string outputPath, string outputTemplate)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? throw new NullReferenceException());
        return File.WriteAllTextAsync(outputPath, outputTemplate);
    }

    /// <summary>
    /// Populates a template asynchronously based on the given parameters.
    /// </summary>
    /// <param name="pathTemplate">The path to the template file.</param>
    /// <param name="module">The module name for the file.</param>
    /// <param name="name">The name used in the template.</param>
    /// <returns>A task representing the asynchronous operation. The resulting populated template as a string.</returns>
    private async Task<string> PopulateTemplateAsync(string pathTemplate, string module, string name)
    {
        var template = await File.ReadAllTextAsync(pathTemplate);
        var snakeCase = string.IsNullOrEmpty(name) ? string.Empty : ToSnakeCase(name);
        var camelCase = string.IsNullOrEmpty(name) ? string.Empty : ToCamelCase(name);
        var output = template.Replace("{{Name}}", name)
                             .Replace("{{name}}", camelCase)
                             .Replace("{{_name}}", snakeCase)
                             .Replace("{{Module}}", module);

        return output;
    }

    /// <summary>
    /// Converts a given string to snake case.
    /// </summary>
    /// <param name="name">The string to be converted.</param>
    /// <returns>The converted string in snake case.</returns>
    private string ToSnakeCase(string name)
    {
        var snakeCaseStrategy = new SnakeCaseNamingStrategy();
        return snakeCaseStrategy.GetPropertyName(name, false);
    }

    /// <summary>
    /// Converts a given string to camel case.
    /// </summary>
    /// <param name="name">The string to be converted.</param>
    /// <returns>The converted string in camel case.</returns>
    private string ToCamelCase(string name)
    {
        var camelCaseStrategy = new CamelCaseNamingStrategy();
        return camelCaseStrategy.GetPropertyName(name, false);
    }
}