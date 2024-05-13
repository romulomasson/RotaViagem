using Microsoft.Extensions.Logging;

namespace RotaViagem.Api.Logger;

public class TraceLoggerProvider : ILoggerProvider
{
    public ILogger CreateLogger(string categoryName) => new TraceLogger(categoryName);

    public void Dispose() { }
}








