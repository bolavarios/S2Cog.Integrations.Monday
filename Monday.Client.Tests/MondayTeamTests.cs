using FakeItEasy;
using GraphQL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monday.Client.Models;
using Monday.Client.Responses;
using Shouldly;
using System.Threading.Tasks;

namespace Monday.Client.Tests;

[TestClass]
public class MondayTeamTests : MondayTests
{
    private void FakeGetTeamsRequest()
    {
        A.CallTo(() => _graphQlClient.SendMutationAsync<GetTeamsResponse>(A<GraphQLRequest>._, default))
            .Returns(new GraphQLResponse<GetTeamsResponse>
            {
                Data = new GetTeamsResponse(new[] { new Team { Id = _random.NextUInt64() } })
            });
    }

    private void FakeGetTeamRequest(ulong id)
    {
        A.CallTo(() => _graphQlClient.SendMutationAsync<GetTeamsResponse>(A<GraphQLRequest>._, default))
            .Returns(new GraphQLResponse<GetTeamsResponse>
            {
                Data = new GetTeamsResponse(new[] { new Team { Id = id } })
            });
    }

    [TestMethod]
    public async Task GetTeams_Pass()
    {
        FakeGetTeamsRequest();

        var result = await _mondayClient.GetTeams();
        result.ShouldNotBeNull();
    }

    [TestMethod]
    public async Task GetTeam_Pass()
    {
        var teamId = _random.NextUInt64();

        FakeGetTeamRequest(teamId);

        var result = await _mondayClient.GetTeam(teamId);
        result.ShouldNotBeNull();
    }
}

