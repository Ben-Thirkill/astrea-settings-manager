namespace api.Core.Settings.SettingTypes;

public abstract class BaseSettingType
{
    public abstract bool Validate(object? value);
    public abstract string Serialize(object? value);
    public abstract object? Deserialize(string serializedValue);

}