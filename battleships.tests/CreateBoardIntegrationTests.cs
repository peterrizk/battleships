using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using battleships.api;
using battleships.application;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace battleships.tests
{
    /// This is a basic integration test to show all the cases can be tested in an easy and readable way
    /// TODO:
    /// test all the arguement validation,
    /// test moving off the 10 by 10 board, 
    /// test overlapping adding of ships,
    /// test creating the board multiple times
    /// test more miss scenarios
    public class CreateBoardAndShipAndAttackIntegrationTests : IClassFixture<WebApplicationFactory<Startup>>
    {

        readonly HttpClient _client;

        public CreateBoardAndShipAndAttackIntegrationTests(WebApplicationFactory<Startup> fixture)
        {
            _client = fixture.CreateClient();
        }



        [Fact]//inject theories and inline data is also an option here
        public async Task Test()
        {
            var response = await _client.GetAsync("/board/create");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response = await _client.GetAsync("/board/addship?team=0&x=0&y=0&length=5&direction=1");
            var val = await StreamToStringAsync(await response.Content.ReadAsStreamAsync());
            var expected = new Team?[,] { { Team.Team1, Team.Team1,Team.Team1,Team.Team1,Team.Team1,null,null,null,null,null },
                                               { null, null, null, null, null, null, null, null, null, null },
                                               { null, null, null, null, null, null, null, null, null, null },
                                               { null, null, null, null, null, null, null, null, null, null },
                                               { null, null, null, null, null, null, null, null, null, null },
                                               { null, null, null, null, null, null, null, null, null, null },
                                               { null, null, null, null, null, null, null, null, null, null },
                                               { null, null, null, null, null, null, null, null, null, null },
                                               { null, null, null, null, null, null, null, null, null, null },
                                               { null, null, null, null, null, null, null, null, null, null }, };
            var expectedStr = JsonConvert.SerializeObject(expected);
            val.Should().Be(expectedStr);
            response = await _client.GetAsync("/board/attack?fromTeam=1&x=0&y=0");
            val = await StreamToStringAsync(await response.Content.ReadAsStreamAsync());
            val.Should().Be("hit");
            response = await _client.GetAsync("/board/attack?fromTeam=0&x=0&y=0");
            val = await StreamToStringAsync(await response.Content.ReadAsStreamAsync());
            val.Should().Be("miss");
        }

        public static async Task<string> StreamToStringAsync(Stream stream)
        {
            string content = null;

            if (stream != null)
                using (var sr = new StreamReader(stream))
                    content = await sr.ReadToEndAsync();

            return content;
        }

    }
}
