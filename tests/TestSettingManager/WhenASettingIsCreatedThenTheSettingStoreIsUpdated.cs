using api.Core.Builders;
using api.Core.Managers;
using api.Core.Models;
using api.Core.Settings.SettingTypes;
using api.Core.Stores;

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
        _store.Clear();
        
        int oldItemCount = _store.Count;

        SettingBuilder builder = new("Setting123", new BooleanType());
        Setting setting = builder.SetName("Setting 123")
            .SetDescription("Setting Description")
            .SetModule("Finance")
            .SetDefaultValue("123")
            .Build();
        
        _settingManager.AddSetting(setting);
        
        int newItemCount = _store.Count;
        
        Assert.That(oldItemCount, Is.EqualTo(0));
        Assert.That(newItemCount, Is.EqualTo(1));
    }

    [Test]
    public void SettingStoreHasCorrectValue()
    {
        _store.Clear();
        
        SettingBuilder builder = new("Setting123", new BooleanType());
        Setting setting = builder.SetName("Setting 123")
            .SetDescription("Setting Description")
            .SetModule("Finance")
            .SetDefaultValue("123")
            .Build();
        
        _settingManager.AddSetting(setting);
        
        Assert.That(_store.Get("Setting123").Name, Is.EqualTo("Setting 123"));
    }
}