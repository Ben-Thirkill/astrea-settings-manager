using api.Core.Models;
using api.Core.Settings.SettingTypes;

namespace api.Core.Builders;

public class SettingBuilder
{
    private readonly string _id;
    private string _module = string.Empty;
    private string _name = string.Empty;
    private string _description = string.Empty;
    private string _defaultValue = string.Empty;
    private readonly BaseSettingType _type;

    public SettingBuilder(string id, BaseSettingType baseSettingType)
    {
        _id = id ?? throw new ArgumentNullException(nameof(id));
        _type = baseSettingType ?? throw new ArgumentNullException(nameof(baseSettingType));
    }

    public SettingBuilder SetModule(string module)
    {
        _module = module;
        return this;
    }

    public SettingBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public SettingBuilder SetDescription(string description)
    {
        _description = description;
        return this;
    }

    public SettingBuilder SetDefaultValue(string defaultValue)
    {
        _defaultValue = defaultValue;
        return this;
    }
    
    public Setting Build()
    {
        if (string.IsNullOrWhiteSpace(_name))
            throw new InvalidOperationException($"Setting '{_id}': Name is not set.");

        if (string.IsNullOrWhiteSpace(_description))
            throw new InvalidOperationException($"Setting '{_id}': Description is not set.");

        if (string.IsNullOrWhiteSpace(_defaultValue))
            throw new InvalidOperationException($"Setting '{_id}': Description is not set.");

        if (_type == null)
            throw new InvalidOperationException($"Setting '{_id}': Type must be specified.");

        if (string.IsNullOrWhiteSpace(_module))
            throw new InvalidOperationException($"Setting '{_id}': Module is not set.");
        
        return new Setting(
            id: _id,
            module: _module,
            name: _name,
            description: _description,
            defaultValue: _defaultValue,
            type: _type
        );
    }

}