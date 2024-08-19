// <copyright file="AppConfigurationServiceTest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Application.Common.Dto.Request;
using Garuda.Application.Common.Dto.Response;
using Garuda.Application.Common.Services.V1;
using Garuda.Domain.Common.Models;
using Garuda.Persistences.Abstract.Contracts;
using Garuda.Repository.Common.Repositories.Contracts;
using Garuda.Utilities.Dtos.Response;
using MapsterMapper;
using Moq;
using Sieve.Models;
using Sieve.Services;
using Xunit;

namespace Garuda.Application.Common.Test.Services.V1;

public class AppConfigurationServiceTest
{
    private readonly Mock<IStorage> _mockStorage;
    private readonly Mock<IMapper> _mockMapper;
    private readonly Mock<ISieveProcessor> _mockSieveProcessor;
    private readonly Mock<IAppConfigurationRepository> _mockAppConfigurationRepository;

    public AppConfigurationServiceTest()
    {
        _mockStorage = new Mock<IStorage>();
        _mockMapper = new Mock<IMapper>();
        _mockSieveProcessor = new Mock<ISieveProcessor>();
        _mockAppConfigurationRepository = new Mock<IAppConfigurationRepository>();
        _mockStorage.Setup(s => s.GetRepository<IAppConfigurationRepository>())
                    .Returns(_mockAppConfigurationRepository.Object);
    }

    [Fact]
    public async Task Get_ById_ReturnsExpectedResult()
    {
        // Arrange
        var id = Guid.NewGuid();
        var configuration = new AppConfiguration();
        var expectedResponse = new AppConfigurationResponse();

        _mockStorage.Setup(r => r.GetRepository<IAppConfigurationRepository>().Get(id)).ReturnsAsync(configuration);
        _mockMapper.Setup(m => m.From(configuration).AdaptToType<AppConfigurationResponse>()).Returns(expectedResponse);

        // Act
        var service = new AppConfigurationService(_mockStorage.Object, _mockMapper.Object, _mockSieveProcessor.Object);
        var result = await service.Get(id);

        // Assert
        _mockAppConfigurationRepository.Verify(repo => repo.Get(id), Times.Once);
        Assert.NotNull(result);
        Assert.Equal(expectedResponse, result);
    }

    [Fact]
    public async Task Get_ReturnsNonNullResult_WhenValidKeyIsProvided()
    {
        // Arrange
        var testKey = "testKey";
        var configuration = new AppConfiguration();
        var expectedResponse = new AppConfigurationResponse();

        _mockAppConfigurationRepository.Setup(repo => repo.Get(testKey)).ReturnsAsync(configuration);
        _mockMapper.Setup(m => m.From(configuration).AdaptToType<AppConfigurationResponse>()).Returns(expectedResponse);

        // Act
        var service = new AppConfigurationService(_mockStorage.Object, _mockMapper.Object, _mockSieveProcessor.Object);
        var result = await service.Get(testKey);

        // Assert
        _mockAppConfigurationRepository.Verify(repo => repo.Get(testKey), Times.Once);
        Assert.NotNull(result);
        Assert.Equal(expectedResponse, result);
    }

    [Fact]
    public Task GetList_ReturnsPaginatedList_WhenSieveModelIsProvided()
    {
        // Arrange
        var sieveModel = new SieveModel { Page = 1, PageSize = 10 };
        var appConfigurationResultMock = new List<AppConfiguration>()
        {
            new() { Id = Guid.Parse("AA3E1CAB-417F-4825-80FD-9A095C70FA98"), Key = "/" },
            new() { Id = Guid.Parse("9D0781BA-4D62-4A8B-8257-2E929A6BE341"), Key = "correct_key" },
            new() { Id = Guid.Parse("D1EEDC71-3171-49F9-9C6E-00147302AC52"), Key = "visited_key" }
        }.AsQueryable();
        var appConfigurationResponseMock = new List<AppConfigurationResponse>()
        {
            new() { Id = Guid.Parse("AA3E1CAB-417F-4825-80FD-9A095C70FA98"), Key = "/" },
            new() { Id = Guid.Parse("9D0781BA-4D62-4A8B-8257-2E929A6BE341"), Key = "correct_key" },
            new() { Id = Guid.Parse("D1EEDC71-3171-49F9-9C6E-00147302AC52"), Key = "visited_key" }
        }.AsQueryable();

        _mockStorage.Setup(stor => stor.GetRepository<IAppConfigurationRepository>())
                    .Returns(_mockAppConfigurationRepository.Object);
        _mockAppConfigurationRepository.Setup(repo => repo.Query()).Returns(appConfigurationResultMock);
        _mockMapper
            .Setup(m =>
                       m.Map<IQueryable<AppConfiguration>, IQueryable<AppConfigurationResponse>>(It.IsAny<IQueryable<
                           AppConfiguration>>()))
            .Returns(appConfigurationResponseMock);
        _mockSieveProcessor.Setup(m => m.Apply(sieveModel, appConfigurationResponseMock, null, true, true, true))
                           .Returns(appConfigurationResponseMock);

        // Act
        var result =
            new PaginatedList<AppConfigurationResponse>(_mockSieveProcessor.Object
                                                                           .Apply(sieveModel,
                                                                            appConfigurationResponseMock)
                                                                           .ToList(),
                                                        appConfigurationResultMock.Count(),
                                                        sieveModel.Page ?? 1,
                                                        sieveModel.PageSize ?? 10);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<PaginatedList<AppConfigurationResponse>>(result);
        Assert.Equal(result.TotalPages,
                     (int)Math.Ceiling(appConfigurationResultMock.Count() / (double)(sieveModel.PageSize ?? 1)));
        Assert.Equal(result.Page, sieveModel.Page ?? 1);
        return Task.CompletedTask;
    }

    [Fact]
    public async Task Update_ReturnsMessageDto_WhenDataIsUpdated()
    {
        // Arrange
        var id = Guid.NewGuid();
        var request = new AppConfigurationRequest();
        var model = new AppConfiguration();

        _mockMapper.Setup(m => m.From(request).AdaptToType<AppConfiguration>()).Returns(model);
        _mockAppConfigurationRepository.Setup(r => r.Update(id, It.IsAny<AppConfiguration>())).ReturnsAsync(model);
        _mockStorage.Setup(s => s.GetRepository<IAppConfigurationRepository>())
                    .Returns(_mockAppConfigurationRepository.Object);
        _mockStorage.Setup(s => s.SaveAsync()).Returns(Task.CompletedTask);

        var service = new AppConfigurationService(_mockStorage.Object, _mockMapper.Object, _mockSieveProcessor.Object);

        // Act
        await service.Update(id, request);

        // Assert
        _mockAppConfigurationRepository.Verify(repo => repo.Update(id, model), Times.Once);
        _mockStorage.Verify(repo => repo.SaveAsync(), Times.Once);
    }
}