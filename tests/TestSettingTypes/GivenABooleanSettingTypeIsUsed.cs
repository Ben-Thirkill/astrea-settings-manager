using api.Core.Builders;
using api.Core.Managers;
using api.Core.Models;
using api.Core.Settings.SettingTypes;
using api.Core.Stores;

public class BooleanSettingTypeTest
{

    private readonly BooleanSettingType _settingType = new();

    [Test]
    public void BooleanSettingTypeToStringIsCorrect()
    {
        Assert.That(_settingType.ToString(), Is.EqualTo("boolean"));
    }

    [Test]
    public void BooleanSettingTypeSerializationIsCorrect()
    {
        Assert.That(_settingType.Serialize(true), Is.EqualTo("true"));
        Assert.That(_settingType.Serialize(false), Is.EqualTo("false"));
    }

    [Test]
    public void BooleanSettingTypeDeserializationIsCorrect()
    {
        Assert.That(_settingType.Deserialize("true"), Is.EqualTo(true));
        Assert.That(_settingType.Deserialize("false"), Is.EqualTo(false));
        Assert.Throws<Exception>(() =>  _settingType.Deserialize("null"));

    }
}