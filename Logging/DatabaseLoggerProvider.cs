using Microsoft.Extensions.Logging;
using CoreSkillsApp.Models;

public class DatabaseLoggerProvider : ILoggerProvider
{
    private readonly IServiceProvider _serviceProvider;

    public DatabaseLoggerProvider(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public ILogger CreateLogger(string categoryName)
    {
        var scope = _serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<MyDbContext>();
        return new DatabaseLogger(categoryName, context);
    }

    public void Dispose() { }
}
