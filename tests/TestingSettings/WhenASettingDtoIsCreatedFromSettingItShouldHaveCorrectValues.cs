using api.Api.Dtos;
using api.Core.Builders;
using api.Core.Managers;
using api.Core.Models;
using api.Core.Settings.SettingTypes;
using api.Core.Stores;

public class SettingDtoTests
{
    
    [Test]
    public void SettingDtoIsCreatedAndHasCorrectValues()
    {
     
        Setting setting = new SettingBuilder("Setting123", new BooleanSettingType())
            .SetName("Setting 123")
            .SetDescription("Setting Description")
            .SetModule("Finance")
            .SetDefaultValue("123")
            .Build();

        SettingDto dto = SettingDto.FromSetting(setting);
       
        Assert.That(dto.Id, Is.EqualTo("Setting123"));
        Assert.That(dto.Type, Is.EqualTo("boolean"));
    }

}