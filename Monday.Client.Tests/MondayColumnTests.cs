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
public class MondayColumnTests : MondayTests
{
    private void FakeCreateColumnResponse(string name)
    {
        A.CallTo(() => _graphQlClient.SendMutationAsync<CreateColumnResponse>(A<GraphQLRequest>._, default))
            .Returns(new GraphQLResponse<CreateColumnResponse>
            {
                Data = new CreateColumnResponse(new Column
                {
                    Id = _random.NextString(),
                    Name = name
                })
            });
    }

    [TestMethod]
    public async Task CreateColumn_Pass()
    {
        var boardId = _random.NextUInt64();
        var name = _random.NextString();

        FakeCreateColumnResponse(name);

        var result = await _mondayClient.CreateColumn(new CreateColumn(boardId, name, ColumnTypes.Status));

        result.ShouldNotBeNull();
        result.ShouldNotBe(string.Empty);
    }

    [TestMethod]
    public async Task UpdateColumn_Pass()
    {
        var boardId = _random.NextUInt64();
        var itemId = _random.NextUInt64();
        var columnId = _random.NextString();

        var result = await _mondayClient.UpdateColumn(new UpdateColumn(boardId, itemId, columnId, "{\"index\": 1}"));

        result.ShouldBeTrue();
    }
}

