namespace FileDownloaderAPI.Producer;

using MassTransit;
using Microsoft.AspNetCore.Mvc;

using FileDownloaderAPI.Contracts;

[ApiController]
[Route("[controller]")]
public class FileUriController : ControllerBase
{
    private readonly ILogger<FileUriController> _logger;
    private readonly IBus _bus;

    public FileUriController(ILogger<FileUriController> logger, IBus bus)
    {
        _logger = logger;
        _bus = bus;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Welcome to the File Downloader API!");
    }

    [HttpGet("{*uri}")]
    public async Task<IActionResult> Get(string uri)
    {
        if (Uri.IsWellFormedUriString(uri, UriKind.Absolute) == false)
        {
            _logger.LogError("Invalid URI format.");
            return BadRequest("Invalid URI format.");
        }
        
        await _bus.Publish(new UriMessage(uri));
        _logger.LogInformation("URI {uri} has been sent.", uri);
        return Ok($"URI {uri} has been sent.");
    }
}