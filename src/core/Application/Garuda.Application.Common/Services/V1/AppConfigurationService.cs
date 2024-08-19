// <copyright file="AppConfigurationService.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Application.Common.Dto.Request;
using Garuda.Application.Common.Dto.Response;
using Garuda.Application.Common.Services.V1.Contracts;
using Garuda.Domain.Common.Models;
using Garuda.Persistences.Abstract.Contracts;
using Garuda.Repository.Common.Repositories.Contracts;
using Garuda.Utilities.Dtos.Response;
using Mapster;
using MapsterMapper;
using Sieve.Models;
using Sieve.Services;

namespace Garuda.Application.Common.Services.V1;

public class AppConfigurationService : IAppConfigurationService
{
    private readonly IStorage _storage;
    private readonly IMapper _mapper;
    private readonly ISieveProcessor _sieveProcessor;

    /// <summary>
    /// Initializes a new instance of the <see cref="AppConfigurationService"/> class.
    /// </summary>
    /// <param name="storage"></param>
    /// <param name="mapper"></param>
    /// <param name="sieveProcessor"></param>
    public AppConfigurationService(IStorage storage, IMapper mapper, ISieveProcessor sieveProcessor)
    {
        _storage = storage;
        _mapper = mapper;
        _sieveProcessor = sieveProcessor;
    }

    public async Task<AppConfigurationResponse> Get(Guid id)
    {
        return _mapper.From(await _storage.GetRepository<IAppConfigurationRepository>().Get(id))
                      .AdaptToType<AppConfigurationResponse>();
    }

    public async Task<AppConfigurationResponse> Get(string key)
    {
        return _mapper.From(await _storage.GetRepository<IAppConfigurationRepository>().Get(key))
                      .AdaptToType<AppConfigurationResponse>();
    }

    public async Task<PaginatedList<AppConfigurationResponse>> GetList(SieveModel sieveModel)
    {
        var query = _storage.GetRepository<IAppConfigurationRepository>()
                            .Query()
                            .ProjectToType<AppConfigurationResponse>();

        return await PaginatedList<AppConfigurationResponse>.CreateAsync(_sieveProcessor.Apply(sieveModel,
                                                                          query,
                                                                          applyPagination: false),
                                                                         sieveModel.Page ?? 1,
                                                                         sieveModel.PageSize ?? 10);
    }

    public async Task Update(Guid id, AppConfigurationRequest model)
    {
        var appConfiguration = _mapper.From(model).AdaptToType<AppConfiguration>();

        await _storage.GetRepository<IAppConfigurationRepository>().Update(id, appConfiguration);
        await _storage.SaveAsync();
    }
}