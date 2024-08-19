// <copyright file="HttpResponseLibraryException.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

namespace Garuda.Utilities.Exceptions;

public class HttpResponseLibraryException : Exception
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="HttpResponseLibraryException" /> class.
    /// </summary>
    /// <param name="status"></param>
    /// <param name="title">Title errors</param>
    /// <param name="message">Message errors</param>
    /// <param name="detail"></param>
    public HttpResponseLibraryException(int status, string title, string message, object? detail = null)
    {
        Status = status;
        Title = title;
        Message = message;
        Detail = detail;
    }

    /// <summary>
    /// Gets or sets for Status.
    /// Extended from Code.
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    ///     Gets or sets for Title
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    ///     Gets for Message
    /// </summary>
    public override string Message { get; }

    /// <summary>
    ///     Gets or sets for Object
    /// </summary>
    public object? Detail { get; set; }
}