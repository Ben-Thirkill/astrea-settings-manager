namespace api.Core.Settings.SettingTypes;

public abstract class SettingType<T> : BaseSettingType
{
    protected abstract bool ValidateTyped(T value);

    public override bool Validate(object? value)
    {
        if (value is T t)
        {
            return ValidateTyped(t);
        }

        return false;
    }
}