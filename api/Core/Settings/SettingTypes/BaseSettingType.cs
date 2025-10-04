namespace api.Core.Settings.SettingTypes;

public abstract class BaseSettingType
{
    public abstract bool Validate(object? value);
}