namespace api.Core.Stores;

public sealed class SettingStore
{
    
    private readonly List<string> _settings = new();

    public int Count => _settings.Count;
    
    public static SettingStore Instance { get; } = new SettingStore();
    private SettingStore() {}


}
