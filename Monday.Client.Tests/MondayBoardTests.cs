using FakeItEasy;
using GraphQL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monday.Client.Models;
using Monday.Client.Mutations;
using Monday.Client.Responses;
using Shouldly;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Monday.Client.Tests;

[TestClass]
public class MondayBoardTests : MondayTests
{
    private void FakeGetBoardsResponse(ulong? boardId = null)
    {
        var boardList = new List<Board>();
        if (boardId != null)
        {
            boardList.Add(new Board
            {
                Id = boardId
            });
        }

        A.CallTo(() => _graphQlClient.SendQueryAsync<GetBoardsResponse>(A<GraphQLRequest>._, default))
            .Returns(new GraphQLResponse<GetBoardsResponse>
            {
                Data = new GetBoardsResponse(boardList)
            });
    }

    private void FakeCreateBoardsResponse(string name)
    {
        A.CallTo(() => _graphQlClient.SendMutationAsync<CreateBoardResponse>(A<GraphQLRequest>._, default))
            .Returns(new GraphQLResponse<CreateBoardResponse>
            {
                Data = new CreateBoardResponse(new Board
                {
                    Id = _random.NextUInt64(),
                    Name = name
                }
                )
            });
    }

    [TestMethod]
    public async Task GetBoards_Pass()
    {
        FakeGetBoardsResponse();

        var result = await _mondayClient.GetBoards();
        result.ShouldNotBeNull();
    }

    [TestMethod]
    public async Task GetBoard_Pass()
    {
        var boardId = _random.NextUInt64();

        FakeGetBoardsResponse(boardId);

        var result = await _mondayClient.GetBoard(boardId);
        result.ShouldNotBeNull();
    }

    [TestMethod]
    public async Task CreateBoard_Pass()
    {
        var name = _random.NextString();

        FakeCreateBoardsResponse(name);

        var result = await _mondayClient.CreateBoard(new CreateBoard(name, BoardAccessTypes.Public));

        result.ShouldBeGreaterThan(0ul);
    }

    [TestMethod]
    public async Task ArchiveBoard_Pass()
    {
        var boardId = _random.NextUInt64();

        var result = await _mondayClient.ArchiveBoard(boardId);
        result.ShouldBeTrue();
    }
}

