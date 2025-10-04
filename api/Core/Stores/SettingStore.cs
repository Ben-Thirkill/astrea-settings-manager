using api.Core.Models;

namespace api.Core.Stores;

public sealed class SettingStore
{
    
    private readonly Dictionary<string, Setting> _settings = new();

    public int Count => _settings.Count;

    public void Add(Setting setting)
    {
        _settings.Add(setting.Id, setting);
    }

    public Setting Get(string id)
    {
        return _settings[id];
    }
    
    public static SettingStore Instance { get; } = new SettingStore();
    private SettingStore() {}


}
