namespace api.Core.Settings.SettingTypes;

public sealed class StringSettingType : SettingType<string>
{
    protected override bool ValidateTyped(string value)
    {
        return true;
    }

    protected override string SerializeTyped(string value)
    {
        return value;
    }
    
    protected override string DeserializeTyped(string serializedValue)
    {
        return serializedValue;
    }
    
    public override string ToString()
    {
        return "string";
    }
}