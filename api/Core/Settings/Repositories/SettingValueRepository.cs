using System.Collections.Concurrent;
using api.Core.Models;

namespace api.Core.Settings.Repositories;

public class SettingValueRepository
{
    private readonly ConcurrentDictionary<ClientApiKey, ConcurrentDictionary<SettingId, object>> _store = new();

    public Task<object?> GetAsync(ClientApiKey clientApiKey, SettingId settingId)
    {
        if (_store.TryGetValue(clientApiKey, out var clientSettings) &&
            clientSettings.TryGetValue(settingId, out var value))
        {
            return Task.FromResult<object?>(value);
        }

        return Task.FromResult<object?>(null);
    }

    public Task SaveAsync(ClientApiKey clientApiKey, SettingId settingId, object value)
    {
        var clientSettings = _store.GetOrAdd(clientApiKey, _ => new ConcurrentDictionary<SettingId, object>());
        clientSettings[settingId] = value;
        return Task.CompletedTask;
    }

    public Task ClearAsync()
    {
        _store.Clear();
        return Task.CompletedTask;
    }
}