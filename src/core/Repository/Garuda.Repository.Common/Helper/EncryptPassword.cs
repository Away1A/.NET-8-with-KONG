// <copyright file="EncryptPassword.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

namespace Garuda.Repository.Common.Helper;

public static class EncryptPassword
{
    /// <summary>
    ///     Verify Password.
    /// </summary>
    /// <param name="enteredPassword"></param>
    /// <param name="hashedPassword"></param>
    /// <returns>boolean wether the password is true or false</returns>
    public static bool VerifyPassword(this string enteredPassword, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(enteredPassword, hashedPassword);
    }

    /// <summary>
    ///     Encrypt passwowrd.
    /// </summary>
    /// <param name="password"></param>
    /// <returns>encrypted password based on BCrypt.Net.BCrypt.HassPassword</returns>
    public static string Encrypt(this string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
}