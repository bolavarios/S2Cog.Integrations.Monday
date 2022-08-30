using FakeItEasy;
using GraphQL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monday.Client.Models;
using Monday.Client.Mutations;
using Monday.Client.Responses;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;

namespace Monday.Client.Tests;

[TestClass]
public class MondayItemsTests : MondayTests
{
    private void FakeGetItemResponse(ulong itemId)
    {
        A.CallTo(() => _graphQlClient.SendQueryAsync<GetItemsResponse>(A<GraphQLRequest>._, A<CancellationToken>._))
            .Returns(new GraphQLResponse<GetItemsResponse>
            {
                Data = new GetItemsResponse(new[] { new Item { Id = itemId } })
            });
    }

    private void FakeGetItemsResponse(ulong itemId)
    {
        A.CallTo(() => _graphQlClient.SendQueryAsync<GetBoardItemsResponse>(A<GraphQLRequest>._, A<CancellationToken>._))
            .Returns(new GraphQLResponse<GetBoardItemsResponse>
            {
                Data = new GetBoardItemsResponse(new[] { new Board { Items = new[] { new Item { Id = itemId } } } })
            });
    }

    private void FakeCreateItemResponse(string name)
    {
        A.CallTo(() => _graphQlClient.SendMutationAsync<CreateItemResponse>(A<GraphQLRequest>._, A<CancellationToken>._))
            .Returns(new GraphQLResponse<CreateItemResponse>
            {
                Data = new CreateItemResponse(new Item { Id = _random.NextUInt64(), Name = name })
            });
    }

    private void FakeCustomGetItems(string cmd)
    {
        A.CallTo(() => _graphQlClient.SendMutationAsync<GetItemsResponse>(A<GraphQLRequest>._, A<CancellationToken>._))
            .Returns(new GraphQLResponse<GetItemsResponse>
            {
                Data = new GetItemsResponse(new[] { new Item { Name = cmd } })
            });
    }

    [TestMethod]
    public async Task GetItems_Pass()
    {
        var boardId = _random.NextUInt64();

        FakeGetItemsResponse(boardId);

        var result = await _mondayClient.GetItems(boardId);
        result.ShouldNotBeNull();
    }

    [TestMethod]
    public async Task GetItem_Pass()
    {
        var itemId = _random.NextUInt64();

        FakeGetItemResponse(itemId);

        var result = await _mondayClient.GetItem(itemId);
        result.ShouldNotBeNull();
    }

    [TestMethod]
    public async Task CustomQueryOrMutation_Pass()
    {
        var customQuery = "{ items(ids: [123123123]) { column_values { id text title type value additional_info }}}";

        FakeCustomGetItems(customQuery);

        var result = await _mondayClient.CustomQueryOrMutation<GetItemsResponse>(customQuery);

        result.ShouldNotBeNull();
    }

    [TestMethod]
    public async Task CreateItem_Pass()
    {
        var name = _random.NextString();
        var boardId = _random.NextUInt64();
        var groupId = _random.NextString();

        FakeCreateItemResponse(name);

        var result = await _mondayClient.CreateItem(new CreateItem(name, boardId, groupId));

        result.ShouldNotBeNull();
    }

    [TestMethod]
    public async Task ArchiveItem_Pass()
    {
        var itemId = _random.NextUInt64();

        var result = await _mondayClient.ArchiveItem(itemId);

        result.ShouldBeTrue();
    }

    [TestMethod]
    public async Task DeleteItem_Pass()
    {
        var itemId = _random.NextUInt64();

        var result = await _mondayClient.DeleteItem(itemId);

        result.ShouldBeTrue();
    }
}

