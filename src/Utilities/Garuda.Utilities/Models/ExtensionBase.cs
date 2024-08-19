// <copyright file="ExtensionBase.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Utilities.Contracts;

#pragma warning disable CS8603 // Possible null reference return.

namespace Garuda.Utilities.Models;

public abstract class ExtensionBase : IExtension
{
    public virtual string Name => GetType().FullName;

    public virtual string Description => null;

    public virtual string Url => null;

    public virtual string Version => null;

    public virtual string Authors => null;
}