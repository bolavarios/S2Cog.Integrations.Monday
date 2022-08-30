using FakeItEasy;
using GraphQL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monday.Client.Models;
using Monday.Client.Mutations;
using Monday.Client.Responses;
using Shouldly;
using System.Threading.Tasks;

namespace Monday.Client.Tests;

[TestClass]
public class MondayUpdatesTests : MondayTests
{
    private void FakeCreateUpdateRequest()
    {
        A.CallTo(() => _graphQlClient.SendMutationAsync<CreateUpdateResponse>(A<GraphQLRequest>._, default))
            .Returns(new GraphQLResponse<CreateUpdateResponse>
            {
                Data = new CreateUpdateResponse(new Update { Id = _random.NextUInt64() })
            });
    }

    [TestMethod]
    public async Task CreateUpdate_Pass()
    {
        var itemId = _random.NextUInt64();
        var body = _random.NextString();

        FakeCreateUpdateRequest();

        var result = await _mondayClient.CreateUpdate(new CreateUpdate(itemId, body));

        result.ShouldNotBeNull();
    }

    [TestMethod]
    public async Task ClearItemUpdates_Pass()
    {
        var itemId = _random.NextUInt64();

        var result = await _mondayClient.ClearItemUpdates(itemId);

        result.ShouldBeTrue();
    }
}

