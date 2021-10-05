using Homework1.API.LogServices;
using ILogger = Microsoft.Extensions.Logging.ILogger;
using ILoggerProvider = Microsoft.Extensions.Logging.ILoggerProvider;

namespace Homework1.API.Logger
{
    public class FileLogProvider: ILoggerProvider
    {
        public void Dispose()
        {
            
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger();
        }
    }
}