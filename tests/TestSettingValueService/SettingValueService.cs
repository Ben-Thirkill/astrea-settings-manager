using api.Core.Builders;
using api.Core.Managers;
using api.Core.Models;
using api.Core.Settings.Repositories;
using api.Core.Settings.Services;
using api.Core.Settings.SettingTypes;
using api.Core.Stores;

public class SettingValueServiceTests
{

    private SettingStore _store;
    private SettingManager _settingManager;
    private SettingValueService _settingValueService;
    
    [SetUp]
    public void Setup()
    {
        this._store = SettingStore.Instance;
        this._settingManager = new(_store);
        
        this._store.Clear();
        
        Setting setting = new SettingBuilder("Setting123", new StringSettingType())
            .SetName("Setting 123")
            .SetDescription("Setting Description")
            .SetModule("Finance")
            .SetDefaultValue("123")
            .Build();
        
        _settingManager.AddSetting(setting);
    }

    [Test]
    public async Task WhenASettingHasNoValueThenTheDefaultValueIsUsed()
    {
        var clientApiKey = new ClientApiKey("apikey123");
        var settingId = new SettingId("Setting123");
        var service = new SettingValueService(SettingValueRepository.Instance);

        var result = await service.GetSettingAsync<string>(clientApiKey, settingId);
        Assert.That(result, Is.EqualTo("123"));
    }
    
    [Test]
    public async Task WhenASettingHasAValueThenThatValueIsUsed()
    {
        var clientApiKey = new ClientApiKey("apikey123");
        var settingId = new SettingId("Setting123");
        var service = new SettingValueService(SettingValueRepository.Instance);

        await service.SetSettingAsync(clientApiKey, settingId, "1234");
        var result = await service.GetSettingAsync<string>(clientApiKey, settingId);
        Assert.That(result, Is.EqualTo("1234"));
    }
}