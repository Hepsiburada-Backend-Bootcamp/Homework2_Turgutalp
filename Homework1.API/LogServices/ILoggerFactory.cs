using System;
using ILogger = Homework1.API.LogServices.ILogger;

namespace Homework1.API.LogServices
{
    /// <summary>
    /// ILogger arayuzunu extend eden custom-logger'larin instance'ini olusturmak icin kullanilir.
    /// </summary>
    public interface ILoggerFactory:IDisposable
    {
     ILogger CreateLogger(string categoryName);
     void AddProvider(ILoggerProvider provider);
     
    }
}