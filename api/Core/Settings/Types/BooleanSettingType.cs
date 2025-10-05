namespace api.Core.Settings.SettingTypes;

public sealed class BooleanSettingType : SettingType<bool>
{
    protected override bool ValidateTyped(bool value)
    {
        return true;
    }

    protected override string SerializeTyped(bool value)
    {
        return value ? "true" : "false";
    }
    
    protected override bool DeserializeTyped(string serializedValue)
    {
        if (serializedValue == "true")
            return true;

        if (serializedValue == "false")
            return false;

        throw new Exception("Invalid boolean setting");
    }
    public override string ToString()
    {
        return "boolean";
    }
}