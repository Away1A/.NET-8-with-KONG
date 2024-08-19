// <copyright file="MessageDto.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace Garuda.Utilities.Dtos;

public class MessageDto
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MessageDto"/> class.
    /// </summary>
    /// <param name="title"></param>
    /// <param name="message"></param>
    /// <param name="code"></param>
    /// <param name="status"></param>
    public MessageDto(string title, string message, int code, int status)
    {
        Code = code;
        Status = status;
        Title = title;
        Message = message;
    }

    public MessageDto(string title, string message)
    {
        Title = title;
        Message = message;
    }

    public MessageDto(string message)
    {
        Message = message;
    }

    public int Code { get; set; }

    public int Status { get; set; }

    public string Title { get; set; }

    public string Message { get; set; }
}