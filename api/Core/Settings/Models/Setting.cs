using api.Core.Settings.SettingTypes;

namespace api.Core.Models;

public class Setting
{
    public string Id { get; set; }
    public string Module { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string DefaultValue { get; set; }
    public BaseSettingType Type { get; set; }

    public Setting(string id, string module, string name, string description, string defaultValue, BaseSettingType type)
    {
        this.Id = id;
        this.Module = module;
        this.Name = name;
        this.Description = description;
        this.DefaultValue =  defaultValue;
        this.Type = type;
    }
}