namespace api.Core.Settings.SettingTypes;

public sealed class BooleanType : SettingType<bool>
{
    protected override bool ValidateTyped(bool value)
    {
        return true;
    }
}