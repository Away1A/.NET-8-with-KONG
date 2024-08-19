// <copyright file="UserService.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Application.Common.Dto;
using Garuda.Application.Common.Dto.Request;
using Garuda.Application.Common.Dto.Response;
using Garuda.Application.Common.Services.V1.Contracts;
using Garuda.Domain.Common.Models;
using Garuda.Persistences.Abstract.Contracts;
using Garuda.Repository.Common.Repositories.Contracts;
using Garuda.Utilities.Dtos.Response;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sieve.Models;
using Sieve.Services;

#pragma warning disable CS8603 // Possible null reference return.

namespace Garuda.Application.Common.Services.V1;

public class UserService : IUserService
{
    private readonly ILogger _logger;
    private readonly IMapper _mapper;
    private readonly IStorage _storage;
    private readonly ISieveProcessor _sieveProcessor;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserService"/> class.
    /// </summary>
    /// <param name="storage"></param>
    /// <param name="mapper"></param>
    /// <param name="logger"></param>
    /// <param name="sieveProcessor"></param>
    public UserService(IStorage storage, IMapper mapper, ILogger<UserService> logger, ISieveProcessor sieveProcessor)
    {
        _storage = storage;
        _mapper = mapper;
        _sieveProcessor = sieveProcessor;
        _logger = logger;
    }

    public async Task<UserResponse> GetById(Guid id)
    {
        return await _storage.GetRepository<IUserRepository>()
                             .Query()
                             .ProjectToType<UserResponse>()
                             .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<PaginatedList<UserResponse>> GetList(SieveModel sieveModel)
    {
        var query = _storage.GetRepository<IUserRepository>().Query().ProjectToType<UserResponse>();
        return await PaginatedList<UserResponse>.CreateAsync(_sieveProcessor.Apply(sieveModel,
                                                              query,
                                                              applyPagination: false),
                                                             sieveModel.Page ?? 1,
                                                             sieveModel.PageSize ?? 10);
    }

    public async Task<UserProfileResponse> GetUserProfile(SessionDto session)
    {
        return _mapper.From(await _storage.GetRepository<IUserRepository>().GetAndValidateById(session.UserId))
                      .AdaptToType<UserProfileResponse>();
    }

    public async Task Create(PostUserRequest model)
    {
        await _storage.GetRepository<IUserRepository>().ValidateDuplicateByName(model.Username);
        var user = TransformCreateUser(model);

        await _storage.GetRepository<IUserRepository>().Create(user);
        await HandleUserRole(user.Id, model.UserRoles);
        await _storage.SaveAsync();
    }

    public async Task Update(Guid id, PutUserRequest model)
    {
        await _storage.GetRepository<IUserRepository>().ValidateDuplicateByIdAndByName(id, model.Username);
        var user = await _storage.GetRepository<IUserRepository>().Get(id);
        TransformPutUser(user, model);

        await _storage.GetRepository<IUserRepository>().Update(id, user);
        await HandleUserRole(user.Id, model.UserRoles);
        await _storage.SaveAsync();
    }

    public async Task Delete(Guid id)
    {
        await _storage.GetRepository<IUserRepository>().Delete(id);
        await _storage.SaveAsync();
    }

    /// <summary>
    /// Handles the user group for a given user.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <param name="roles">The list of user groups to be associated with the user.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task HandleUserRole(Guid userId, List<RoleRequest> roles)
    {
        foreach (var role in roles)
        {
            await _storage.GetRepository<IUserRoleRepository>().DeleteByUserIdAndRoleId(userId, role.Id);
        }

        foreach (var userRole in roles.Select(group => new UserRole { RoleId = group.Id, UserId = userId, }))
        {
            await _storage.GetRepository<IUserRoleRepository>().Create(userRole);
        }
    }

    /// <summary>
    /// Transforms a PostUserRequest object into a User object.
    /// </summary>
    /// <param name="model">The PostUserRequest object to be transformed.</param>
    /// <returns>A User object.</returns>
    private User TransformCreateUser(PostUserRequest model)
    {
        return new User { Email = model.Email, Username = model.Username, Fullname = model.Fullname, };
    }

    /// <summary>
    /// Transforms the properties of a PutUserRequest object and updates the corresponding User object.
    /// </summary>
    /// <param name="user">The User object to be updated.</param>
    /// <param name="model">The PutUserRequest object containing the updated properties.</param>
    private void TransformPutUser(User user, PutUserRequest model)
    {
        user.Email = model.Email;
        user.Username = model.Username;
        user.Fullname = model.Fullname;
    }
}