using System;
using Microsoft.Extensions.Logging;


namespace Homework1.API.LogServices
{
    /// <summary>
    /// log-storage'a log kaydetmemizi saglayan metodlar
    /// </summary>
    public interface ILogger
    {
        void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
            Func<TState, Exception, string> formatter);

        bool IsEnabled(LogLevel logLevel);
        IDisposable BeginScope<TState>(TState state);
    }
}