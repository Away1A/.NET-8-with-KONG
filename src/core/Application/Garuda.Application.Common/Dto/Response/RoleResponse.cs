// <copyright file="RoleResponse.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Sieve.Attributes;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Garuda.Application.Common.Dto.Response;

public class RoleResponse
{
    public Guid Id { get; set; }

    [Sieve(CanFilter = true, CanSort = true)]
    public string Name { get; set; }
}