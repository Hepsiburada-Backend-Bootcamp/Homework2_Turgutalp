using System;

namespace Homework1.API.LogServices
{
    /// <summary>
    /// Bu interface => projede kullanacagimiz customLogger'in instance'ini
    /// olusturmamizi saglayavaj sinifi tanimlarken kullaniriz.
    /// </summary>
    public interface ILoggerProvider: IDisposable
    {
        Microsoft.Extensions.Logging.ILogger CreateLogger(string categoryName);
    }
}