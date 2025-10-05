using api.Core.Models;
using api.Core.Stores;

namespace api.Core.Managers;

public class SettingManager
{
    private SettingStore _store;
    public SettingManager(SettingStore store)
    {
        this._store = store;
    }

    public void AddSetting(Setting setting)
    {
        this._store.Add(setting);
    }

    public Setting GetSetting(string id)
    {
        return this._store.Get(id);
    }
}