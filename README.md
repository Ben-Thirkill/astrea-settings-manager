This is a quick app/user configuration management service i am using as a learning project. At some point I plan on adding some form of caching, playing around with distributed databases, making a CI/CD pipeline and whatever else I think of.

It's not complete, I'm still working on it.
But here is my vision so far.


# How settings are created and rendered.
A setting can be created on the backend using a fluent-style api. (in quick retrospect it might make sense to store them in a JSON/Yaml file instead of in code.
```c#
Setting _setting = new SettingBuilder("show_contacts", new BooleanSettingType())
    .SetDefaultValue("true")
    .SetName("Show Company Contacts")
    .SetDescription("Show the company contact details on the dashboard?")
    .SetModule("finance_portal")
    .Build();

SettingManager _manager = new SettingManager(SettingStore.Instance);
_manager.AddSetting(_setting);
```
which can be retrieved using
```
[GET] api/settings/GetAll/{Module}
```
This endpoint gets all of the settings in a specific module. A response might look like this.
```json
{
  "app_name": {
    "id": "app_name",
    "module": "finance_portal",
    "name": "App Name",
    "description": "What should we call this app in front of customers?",
    "defaultValue": "Finance Portal",
    "type": "text"
  },
  "show_contacts": {
    "id": "show_contacts",
    "module": "finance_portal",
    "name": "Show Company Contacts",
    "description": "Show the company contact details on the dashboard?",
    "defaultValue": "true",
    "type": "boolean"
  }
}
```
The frontend can pull these settings from the backend, store them and then using an NPM package they could do something like this
```html
<h1>Finance Portal</h1>
<config-setting id="app_name"></config-setting>
<config-setting id="show_contacts"></config-setting>
```
The npm package will have the logic to determine what to display using the settings pulled from the endpoint. Since we know the setting type (text, boolean etc) as long as we validation/serialisation methods, we can easilly retrieve setting values from the server and use them, or change them on the frontend and send them to the server for updates.  I imagine it might look something like this.

<img width="722" height="214" alt="image" src="https://github.com/user-attachments/assets/e277826f-2066-4f5a-b7a2-02428cffe662" />

Doing it this way means it's super easy to add settings on the frontend, but we have the flexibility to move them wherever we want.

This should also help us handle more complicated setting types, as long as the backend and frontend have a shared schema for how they should be serialized/deserialised. All backend would have to do is create a setting new type and make serialisation functions, the frontend can then do whatever they want to make them configurable. 
See a simple example of a setting type. (https://github.com/Ben-Thirkill/astrea-settings-manager/blob/main/api/Core/Settings/Types/SettingTypes/BooleanSettingType.cs)

