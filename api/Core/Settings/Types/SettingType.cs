namespace api.Core.Settings.SettingTypes;

public abstract class SettingType<T> : BaseSettingType
{
    protected abstract bool ValidateTyped(T value);
    protected abstract string SerializeTyped(T value);
    protected abstract T DeserializeTyped(string serializedValue);

    public override bool Validate(object? value)
    {
        if (value is T t)
        {
            return ValidateTyped(t);
        }

        return false;
    }

    public override string Serialize(object? value)
    {
        if (value is T t)
        {
            return SerializeTyped(t);
        }

        throw new Exception("Unable to serialize " + value);
    }
    
    public override object? Deserialize(string serializedValue)
    {
        return DeserializeTyped(serializedValue);
    }
}