using api.Core.Managers;
using api.Core.Models;
using api.Core.Settings.Repositories;
using api.Core.Stores;

namespace api.Core.Settings.Services;

public sealed class SettingValueService
{
    private readonly SettingValueRepository _repository;
    private readonly SettingManager _settingManager =  new SettingManager(SettingStore.Instance);
    
    public SettingValueService(SettingValueRepository repository)
    {
        _repository = repository;
    }

    public async Task<T> GetSettingAsync<T>(ClientApiKey clientApiKey, SettingId settingId)
    {
        var repoValue = await _repository.GetAsync(clientApiKey, settingId);
        if (repoValue is not null)
            return (T)repoValue;

        if (!_settingManager.SettingExists(settingId.ToString()))
        {
            return default;
        }
        
        var setting = _settingManager.GetSetting(settingId.ToString());
        var deserialized = setting.Type.Deserialize(setting.DefaultValue);
            
        await _repository.SaveAsync(clientApiKey, settingId, deserialized!);
        return (T)deserialized!;

    }

    public async Task SetSettingAsync(ClientApiKey clientApiKey, SettingId settingId, object value)
    {
        if (!_settingManager.SettingExists(settingId.ToString()))
        {
            throw new Exception("Setting not found");
        }
        
        await _repository.SaveAsync(clientApiKey, settingId, value);
    }
    public async Task SetSettingFromSerializedAsync(ClientApiKey clientApiKey, SettingId settingId, string serializedValue)
    {
        if (!_settingManager.SettingExists(settingId.ToString()))
        {
            throw new Exception("Setting not found");
        }
        
        var setting = _settingManager.GetSetting(settingId.ToString());
        var deserialized = setting.Type.Deserialize(serializedValue);
        
        await _repository.SaveAsync(clientApiKey, settingId, deserialized);
    }
    public async Task ClearAllAsync()
    {
        await _repository.ClearAsync();
    }
}