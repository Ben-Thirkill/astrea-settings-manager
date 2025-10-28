using api.Core.Models;
using Microsoft.AspNetCore.Mvc;
using api.Core.Settings.Repositories;
using api.Core.Settings.Services;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SettingsController : ControllerBase
{
    private readonly SettingValueService _service;

    public SettingsController()
    {
        this._service = new SettingValueService(SettingValueRepository.Instance);
    }

    [HttpGet("GetSetting/{settingId}")]
    public async Task<ActionResult<object>> GetSetting(
        string settingId,
        [FromHeader(Name = "X-Api-Key")] string apiKey,
        CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(apiKey))
            return BadRequest("Missing API key.");

        var clientKey = new ClientApiKey(apiKey);
        var settingKey = new SettingId(settingId);

        var value = await _service.GetSettingAsync<object>(clientKey, settingKey);
        
        if (value is null)
            return NotFound($"Setting '{settingId}' not found for API key '{apiKey}'.");

        return Ok(value);
    }
    
    [HttpPost("SetSetting/{settingId}")]
    public async Task<ActionResult<object>> SetSetting(
        string settingId,
        [FromHeader(Name = "X-Api-Key")] string apiKey,
        [FromBody] string value, 
        CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(apiKey))
            return BadRequest("Missing API key.");

        var clientKey = new ClientApiKey(apiKey);
        var settingKey = new SettingId(settingId);

        try
        {
            await _service.SetSettingFromSerializedAsync(clientKey, settingKey, value);
            return Ok();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}