namespace api.Core.Models;

public readonly record struct ClientApiKey(string Value)
{
    public override string ToString() => Value;
}
