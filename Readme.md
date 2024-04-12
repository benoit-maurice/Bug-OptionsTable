# About

This repo reproduces an issue with the Options in aspnet core

## Description

Given an aspnet core 8.0 api
And the following option class :

```csharp
public class ConfigOptions
{
    public const string SectionName = "Config";

    public string[] List { get; init; }
}
```

and the folowing appsettings.json :

```json
{
  // ... some irrelevant config
  "Config": {
    "List": ["1", "2", "3"]
  }
  // ... some irrelevant config
}
```

and I register the option twice :

```csharp
builder.Services.AddOptions<ConfigOptions>().Bind(builder.Configuration.GetSection(ConfigOptions.SectionName));
builder.Services.AddOptions<ConfigOptions>().Bind(builder.Configuration.GetSection(ConfigOptions.SectionName));
```

When I inject `IOptions<ConfigOptions>` in a service

Then the List property will contain "1","2","3" twice, that is : `["1","2","3","1","2","3"]`

    Note: If I register the option a third time then the options List will contains "1","2","3" three times

# Reproduction

This [red test](./tests/Bug_OptionsTable.Tests/ConfigRouteShould.cs) shows the expected behaviour.
