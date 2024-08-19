// <copyright file="SieveCommonFilter.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Application.Common.Dto.Response;
using Sieve.Services;

namespace Garuda.Application.Common.Sieves;

public class SieveCommonFilter : ISieveCustomFilterMethods
{
    public IQueryable<UserResponse> Name(IQueryable<UserResponse> source, string op, string[] value)
    {
        return source.Where(x => x.Username.Contains(value[0]) || x.Fullname.Contains(value[0]));
    }
}