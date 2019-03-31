using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

public class App
{
    private readonly ILogger<App> _logger;
    public App(ILogger<App> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public void Run()
    {
    }
}
