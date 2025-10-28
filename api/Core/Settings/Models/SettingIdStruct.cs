namespace api.Core.Models;

public readonly record struct SettingId(string Value)
{
    public override string ToString() => Value;
}
