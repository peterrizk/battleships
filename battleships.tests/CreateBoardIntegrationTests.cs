using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using battleships.api;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace battleships.tests
{
    public class CreateBoardIntegrationTests : IClassFixture<WebApplicationFactory<Startup>>
    {

        readonly HttpClient _client;

        public CreateBoardIntegrationTests(WebApplicationFactory<Startup> fixture)
        {
            _client = fixture.CreateClient();
        }

         [Fact]
        public async Task Test()
        {
            var response = await _client.GetAsync("/board/create");
            response.StatusCode.Should().Be(HttpStatusCode.OK);       
        }
    }
}
