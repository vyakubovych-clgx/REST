using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using REST.Services;

namespace REST.Tests
{
    public class Tests
    {
        [Test]
        public async Task Test()
        {
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();
            var response = await client.GetStringAsync("/api/Category/1");
            StringAssert.Contains("Math", response);
        }
    }
}