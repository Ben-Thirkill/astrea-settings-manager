using api.Core.Managers;
using api.Core.Stores;
using NUnit.Framework;

namespace tests;

public class Tests
{

    private SettingStore _store;
    private SettingManager _settingManager;
    [SetUp]
    public void Setup()
    {
        this._store = SettingStore.Instance;
        this._settingManager = new(_store);
    }

    [Test]
    public void SettingStoreIsUpdated()
    {
        int oldItemCount = _store.Count;

        _settingManager.AddSetting("Setting123");
        int newItemCount = _store.Count;
        
        Assert.That(oldItemCount, Is.EqualTo(0));
        Assert.That(newItemCount, Is.EqualTo(1));
    }
}