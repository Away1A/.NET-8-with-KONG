// <copyright file="MenuPermissionRequest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

namespace Garuda.Application.Common.Dto.Request;

public class MenuPermissionRequest
{
    public Guid Id { get; set; }

    public Guid MenuId { get; set; }

    public bool Create { get; set; }

    public bool Read { get; set; }

    public bool Update { get; set; }

    public bool Delete { get; set; }

    public bool Submit { get; set; }

    public bool Acknowledge { get; set; }

    public bool Edit { get; set; }

    public bool SpecialCaseActual { get; set; }
}