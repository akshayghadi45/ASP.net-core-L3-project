using Microsoft.Extensions.Logging;
using CoreSkillsApp.Models;

public class DatabaseLogger : ILogger
{
    private readonly MyDbContext _context;
    private readonly string _category;

    public DatabaseLogger(string category, MyDbContext context)
    {
        _category = category;
        _context = context;
    }

    public IDisposable? BeginScope<TState>(TState state) => null;

    public bool IsEnabled(LogLevel logLevel) => logLevel != LogLevel.None;

    public void Log<TState>(LogLevel logLevel, EventId eventId,
                            TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        if (!IsEnabled(logLevel)) return;

        var logEntry = new Log
        {
            Description = formatter(state, exception),
            LogLevel = logLevel.ToString(),
            LogTime = DateTime.Now
        };

        _context.Logs.Add(logEntry);
        _context.SaveChanges();
    }
}
