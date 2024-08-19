// <copyright file="SieveCommonSort.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Application.Common.Dto.Response;
using Sieve.Services;

namespace Garuda.Application.Common.Sieves;

public class SieveCommonSort : ISieveCustomSortMethods
{
    public IQueryable<UserResponse> ByName(IQueryable<UserResponse> source, bool useThenBy, bool desc)
    {
        return desc ? source.OrderByDescending(x => x.Fullname) : source.OrderBy(x => x.Fullname);
    }
}