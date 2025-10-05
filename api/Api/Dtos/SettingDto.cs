using api.Core.Models;

namespace api.Api.Dtos;

public class SettingDto
{
    public string Id { get; set; }
    public string Module { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string DefaultValue { get; set; }
    public string Type { get; set; }

    public SettingDto(string id, string module, string name, string description, string defaultValue, string type)
    {
        this.Id = id;
        this.Module = module;
        this.Name = name;
        this.Description = description;
        this.DefaultValue =  defaultValue;
        this.Type = type;
    }
    
    public static SettingDto FromSetting(Setting s) =>
        new SettingDto(s.Id, s.Module, s.Name, s.Description, s.DefaultValue, s.Type.ToString());
}