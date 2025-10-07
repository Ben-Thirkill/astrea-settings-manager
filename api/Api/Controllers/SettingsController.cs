using api.Api.Dtos;
using api.Core.Managers;
using api.Core.Stores;

namespace api.Api.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class SettingsController : ControllerBase
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<Dictionary<string, SettingDto>>> GetAll(CancellationToken ct)
    {
        SettingManager _manager = new SettingManager(SettingStore.Instance);
        var settingList = _manager.GetAll().ToDictionary(
            kvp => kvp.Key,
            kvp => SettingDto.FromSetting(kvp.Value)
        );        
        
        return Ok(settingList);
    }

}
