// <copyright file="Extension.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using Garuda.Utilities.Models;

namespace Garuda.Application.Common;

public class Extension : ExtensionBase
{
    /// <summary>
    ///     Gets the name of the extension.
    /// </summary>
    public override string Name => "Garuda.Application.Common";

    /// <summary>
    ///     Gets the URL of the extension.
    /// </summary>
    public override string Url => "https://www.garudainfinity.com/";

    /// <summary>
    ///     Gets the version of the extension.
    /// </summary>
    public override string Version => "0.0.1";

    /// <summary>
    ///     Gets the authors of the extension (separated by commas).
    /// </summary>
    public override string Authors => "Garuda Infinity Kreasindo";
}