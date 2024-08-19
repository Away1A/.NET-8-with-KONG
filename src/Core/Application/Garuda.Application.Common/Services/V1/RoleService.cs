// <copyright file="RoleService.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Application.Common.Dto.Request;
using Garuda.Application.Common.Dto.Response;
using Garuda.Application.Common.Services.V1.Contracts;
using Garuda.Domain.Common.Models;
using Garuda.Persistences.Abstract.Contracts;
using Garuda.Repository.Common.Repositories.Contracts;
using Garuda.Utilities.Dtos;
using Garuda.Utilities.Dtos.Response;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace Garuda.Application.Common.Services.V1;

public class RoleService : IRoleService
{
    private readonly IStorage _storage;
    private readonly ISieveProcessor _sieveProcessor;
    private readonly IMapper _mapper;

    /// <summary>
    ///     Initializes a new instance of the <see cref="RoleService" /> class.
    /// </summary>
    /// <param name="storage"></param>
    /// <param name="sieveProcessor"></param>
    /// <param name="mapper"></param>
    public RoleService(IStorage storage, ISieveProcessor sieveProcessor, IMapper mapper)
    {
        _storage = storage;
        _sieveProcessor = sieveProcessor;
        _mapper = mapper;
    }

    public async Task<RoleResponse> Get(Guid id)
    {
        return _mapper.From(await _storage.GetRepository<IRoleRepository>()
                                          .Query()
                                          .FirstOrDefaultAsync(x => x.Id == id))
                      .AdaptToType<RoleResponse>();
    }

    public async Task<PaginatedList<RoleResponse>> GetList(SieveModel sieveModel)
    {
        var query = _storage.GetRepository<IRoleRepository>()
                            .Query()
                            .IgnoreQueryFilters()
                            .ProjectToType<RoleResponse>();

        return await PaginatedList<RoleResponse>.CreateAsync(_sieveProcessor.Apply(sieveModel, query),
                                                             sieveModel.Page ?? 1,
                                                             sieveModel.PageSize ?? 10);
    }

    public async Task Create(RoleRequest model)
    {
        await _storage.GetRepository<IRoleRepository>()
                      .Create(_mapper.Map<RoleRequest, Role>(model));
        await _storage.SaveAsync();
    }

    public async Task Update(Guid id, RoleRequest model)
    {
        var group = await _storage.GetRepository<IRoleRepository>()
                                  .Get(id);

        group.Name = model.Name;
        await _storage.SaveAsync();
    }

    public async Task Delete(Guid id)
    {
        await _storage.GetRepository<IRoleRepository>()
                      .Delete(id);
        await _storage.SaveAsync();
    }

    public async Task<List<RoleResponse>> GetData(bool isActive)
    {
        return await _storage.GetRepository<IRoleRepository>()
                             .Query()
                             .IgnoreQueryFilters()
                             .Where(x => isActive ? x.DeletedDate == null : x.DeletedDate != null)
                             .ProjectToType<RoleResponse>()
                             .ToListAsync();
    }
}