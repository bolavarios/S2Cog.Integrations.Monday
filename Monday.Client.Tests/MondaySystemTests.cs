using FakeItEasy;
using GraphQL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monday.Client.Models;
using Monday.Client.Responses;
using Shouldly;
using System.Threading.Tasks;

namespace Monday.Client.Tests;

[TestClass]
public class MondaySystemTests : MondayTests
{
    private void FakeRateLimit()
    {
        A.CallTo(() => _graphQlClient.SendMutationAsync<GetComplexityResponse>(A<GraphQLRequest>._, default))
            .Returns(new GraphQLResponse<GetComplexityResponse>
            {
                Data = new GetComplexityResponse(new Complexity { After = 1234 })
            });
    }

    private void FakeComplexity()
    {
        A.CallTo(() => _graphQlClient.SendMutationAsync<GetComplexityResponse>(A<GraphQLRequest>._, default))
            .Returns(new GraphQLResponse<GetComplexityResponse>
            {
                Data = new GetComplexityResponse(new Complexity { })
            });
    }

    [TestMethod]
    public async Task GetRateLimit_Pass()
    {
        FakeRateLimit();

        var result = await _mondayClient.GetRateLimit();

        result.ShouldBeGreaterThan(0);
    }

    [TestMethod]
    public async Task GetComplexity_Pass()
    {
        FakeComplexity();

        var result = await _mondayClient.GetComplexity("users(kind: non_guests) { id name }");

        result.ShouldNotBeNull();
    }
}

