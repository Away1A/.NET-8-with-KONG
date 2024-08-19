// <copyright file="AppConfigurationRepository.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Domain.Common.Models;
using Garuda.Persistences.Framework;
using Garuda.Repository.Common.Repositories.Contracts;
using Garuda.Utilities.Constants.Errors;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8603 // Possible null reference return.

namespace Garuda.Repository.Common.Repositories;

public class AppConfigurationRepository : RepositoryBase<AppConfiguration>, IAppConfigurationRepository
{
    public IQueryable<AppConfiguration> Query()
    {
        return this.dbSet;
    }

    public async Task<AppConfiguration> Get(Guid id)
    {
        return await this.dbSet.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<AppConfiguration> Get(string key)
    {
        return await this.dbSet.FirstOrDefaultAsync(x => x.Key == key);
    }

    public async Task<AppConfiguration> Update(Guid id, AppConfiguration model)
    {
        var appConfiguration = await this.dbSet.FirstOrDefaultAsync(x => x.Id == id);
        if (appConfiguration == null)
        {
            throw Error.DataNotFound();
        }

        appConfiguration.Description = model.Description;
        appConfiguration.Key = model.Key;
        appConfiguration.Value = model.Value;

        this.dbSet.Update(model);
        return model;
    }
}