using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Bug_OptionsTable.Tests;

public class ConfigRouteShould
{
    [Fact]
    public async Task Return_List_with_only_the_value_from_appsettings()
    {
        var client = new WebApplicationFactory<Program>().CreateClient();
        
        var response = await client.GetAsync("/config");
        
        var config = await response.Content.ReadFromJsonAsync<ConfigOptions>();

        Check.That(config?.List).IsNotNull().And.ContainsExactly("1", "2", "3");
    }
}