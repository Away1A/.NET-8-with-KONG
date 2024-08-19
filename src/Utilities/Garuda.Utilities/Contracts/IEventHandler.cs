// <copyright file="IEventHandler.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

namespace Garuda.Utilities.Contracts;

/// <summary>
/// Event Handler
/// </summary>
public interface IEventHandler
{
    /// <summary>
    /// Gets priority to executed
    /// </summary>
    int Priority { get; }

    /// <summary>
    /// Handler Event
    /// </summary>
    void HandleEvent();
}

/// <summary>
/// Event Handler with argument
/// </summary>
/// <name>TEventArgument</name>
public interface IEventHandler<TEventArgument>
{
    /// <summary>
    /// Gets priority to executed
    /// </summary>
    int Priority { get; }

    /// <summary>
    /// Handle Event with argument
    /// </summary>
    /// <param name="argument"></param>
    void HandleEvent(TEventArgument argument);
}

/// <summary>
/// Event Handler with 2 arguments
/// </summary>
/// <name>TEventArgument1</name>
/// <name>TEventArgument2</name>
public interface IEventHandler<TEventArgument1, TEventArgument2>
{
    /// <summary>
    /// Gets priority to executed
    /// </summary>
    int Priority { get; }

    /// <summary>
    /// Handle Event with 2 arguments
    /// </summary>
    /// <param name="argument1"></param>
    /// <param name="argument2"></param>
    void HandleEvent(TEventArgument1 argument1, TEventArgument2 argument2);
}

/// <summary>
/// Event Handler with 3 arguments
/// </summary>
/// <name>TEventArgument1</name>
/// <name>TEventArgument2</name>
/// <name>TEventArgument3</name>
public interface IEventHandler<TEventArgument1, TEventArgument2, TEventArgument3>
{
    /// <summary>
    /// Gets priority to executed
    /// </summary>
    int Priority { get; }

    /// <summary>
    /// Handle Event with 3 arguments
    /// </summary>
    /// <param name="argument1"></param>
    /// <param name="argument2"></param>
    /// <param name="argument3"></param>
    void HandleEvent(TEventArgument1 argument1, TEventArgument2 argument2, TEventArgument3 argument3);
}