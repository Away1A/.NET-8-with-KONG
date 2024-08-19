// <copyright file="LoginRequest.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace Garuda.Application.Common.Dto.Request;

public class LoginRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LoginRequest"/> class.
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    public LoginRequest(string username, string password)
    {
        Username = username;
        Password = password;
    }

    /// <summary>
    ///     Gets or sets username.
    /// </summary>
    [Required(ErrorMessage = "The Username field is required.")]
    public string Username { get; set; }

    /// <summary>
    ///     Gets or sets user Password login.
    /// </summary>
    [Required(ErrorMessage = "The Password field is required.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}