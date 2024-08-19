// <copyright file="AppConfigurationRepositoryTest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Domain.Common.Models;
using Garuda.Persistences.Framework;
using Garuda.Repository.Common.Repositories;
using Garuda.Repository.Common.Repositories.Contracts;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace Garuda.Repository.Common.Test.Repositories;

[TestSubject(typeof(AppConfigurationRepository))]
public class AppConfigurationRepositoryTest
{
    private readonly AppConfiguration _testConfig = new()
    {
        Id = Guid.Parse("AA3E1CAB-417F-4825-80FD-9A095C70FA98"),
        Key = "testKey",
        Value = "testValue",
        Description = "testDesc"
    };

    private readonly IQueryable<AppConfiguration> _appConfigurations = new List<AppConfiguration>
    {
        new()
        {
            Id = Guid.Parse("AA3E1CAB-417F-4825-80FD-9A095C70FA98"), Key = "/"
        },
        new()
        {
            Id = Guid.Parse("9D0781BA-4D62-4A8B-8257-2E929A6BE341"), Key = "correct_key"
        },
        new()
        {
            Id = Guid.Parse("D1EEDC71-3171-49F9-9C6E-00147302AC52"), Key = "visited_key"
        }
    }.AsQueryable();

    private readonly StorageContextOptions _configData = new()
    {
        ConnectionString = "TestConnectionString"
    };

    private readonly Mock<IAppConfigurationRepository> _mockRepo = new();
    private readonly Mock<DbSet<AppConfiguration>> _mockDbSet = new();

    [Theory]
    [InlineData("/")]
    [InlineData("correct_key")]
    [InlineData("non_visited_key")]
    public async Task TestGetWithKey(string key)
    {
        // Arrange
        _mockRepo.Setup(m => m.Get(key))!.ReturnsAsync(_appConfigurations.FirstOrDefault(x => x.Key == key));

        // Act
        var config = await _mockRepo.Object.Get(key);

        // Asserts
        _mockRepo.Verify(repo => repo.Get(key), Times.Once);
        Assert.Equal(config, _appConfigurations.FirstOrDefault(x => x.Key == key));
    }

    [Theory]
    [InlineData("AA3E1CAB-417F-4825-80FD-9A095C70FA98")]
    [InlineData("9D0781BA-4D62-4A8B-8257-2E929A6BE341")]
    [InlineData("9D0781BA-4D62-4A8B-8257-2E929A6BE345")]
    public async Task TestGetWithId(Guid id)
    {
        // Arrange
        _mockRepo.Setup(m => m.Get(id))!.ReturnsAsync(_appConfigurations.FirstOrDefault(x => x.Id == id));

        // Act
        var config = await _mockRepo.Object.Get(id);

        // Asserts
        _mockRepo.Verify(repo => repo.Get(id), Times.Once);
        Assert.Equal(config, _appConfigurations.FirstOrDefault(x => x.Id == id));
    }

    [Fact]
    public async Task Update_ReturnsAppConfiguration_WhenDataIsUpdated()
    {
        // Arrange
        _mockDbSet.As<IQueryable<AppConfiguration>>()
                  .Setup(m => m.Provider)
                  .Returns(_appConfigurations.Provider);
        _mockDbSet.As<IQueryable<AppConfiguration>>()
                  .Setup(m => m.Expression)
                  .Returns(_appConfigurations.Expression);
        _mockDbSet.As<IQueryable<AppConfiguration>>()
                  .Setup(m => m.ElementType)
                  .Returns(_appConfigurations.ElementType);
        _mockDbSet.As<IQueryable<AppConfiguration>>()
                  .Setup(m => m.GetEnumerator())
                  .Returns(() => _appConfigurations.GetEnumerator());
        _mockDbSet.Setup(m => m.Update(It.IsAny<AppConfiguration>()))
                  .Verifiable();

        var configMock = new Mock<IOptions<StorageContextOptions>>();
        configMock.Setup(x => x.Value)
                  .Returns(_configData);

        var contextMock = new Mock<StorageContextBase>(configMock.Object);
        contextMock.Setup(m => m.Set<AppConfiguration>())
                   .Returns(_mockDbSet.Object);

        _mockRepo.Setup(repo => repo.SetStorageContext(contextMock.Object));
        _mockRepo.Setup(repo => repo.Update(_testConfig.Id, _testConfig))
                 .ReturnsAsync(_testConfig);

        // Act
        var updatedConfiguration = await _mockRepo.Object.Update(_testConfig.Id, _testConfig);

        // Assert
        _mockRepo.Verify(m => m.Update(_testConfig.Id, _testConfig), Times.Once);
        Assert.NotNull(updatedConfiguration);
        Assert.Equal(_testConfig.Description, updatedConfiguration.Description);
        Assert.Equal(_testConfig.Key, updatedConfiguration.Key);
        Assert.Equal(_testConfig.Value, updatedConfiguration.Value);
    }
}