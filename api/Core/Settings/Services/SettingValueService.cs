using api.Core.Managers;
using api.Core.Models;
using api.Core.Settings.Repositories;
using api.Core.Stores;

namespace api.Core.Settings.Services;

public sealed class SettingValueService
{
    private readonly SettingValueRepository _repository;

    public static SettingValueService Instance { get; } = new SettingValueService(new SettingValueRepository());
    private SettingValueService(SettingValueRepository repository)
    {
        _repository = repository;
    }

    public async Task<T> GetSettingAsync<T>(ClientApiKey clientApiKey, SettingId settingId)
    {
        var repoValue = await _repository.GetAsync(clientApiKey, settingId);
        if (repoValue is not null)
            return (T)repoValue;

        var settingManager = new SettingManager(SettingStore.Instance);
        if (settingManager.SettingExists(settingId.ToString()))
        {
            var setting = settingManager.GetSetting(settingId.ToString());
            var deserialized = setting.Type.Deserialize(setting.DefaultValue);
            
            await _repository.SaveAsync(clientApiKey, settingId, deserialized!);
            return (T)deserialized!;
        }

        throw new KeyNotFoundException($"Setting '{settingId}' not found for client '{clientApiKey}'.");
    }

    public async Task SetSettingAsync(ClientApiKey clientApiKey, SettingId settingId, object value)
    {
        await _repository.SaveAsync(clientApiKey, settingId, value);
    }

    public async Task ClearAllAsync()
    {
        await _repository.ClearAsync();
    }
}