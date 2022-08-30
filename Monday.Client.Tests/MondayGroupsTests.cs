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
public class MondayGroupsTests : MondayTests
{
    private void FakeGetGroupsResponse(ulong boardId)
    {
        A.CallTo(() => _graphQlClient.SendMutationAsync<GetGroupsResponse>(A<GraphQLRequest>._, default))
            .Returns(new GraphQLResponse<GetGroupsResponse>
            {
                Data = new GetGroupsResponse(new[] {
                    new Board{
                        Id = boardId,
                        Groups = new[] {
                            new Group {
                                Id = _random.NextString()
                            }
                        }
                    }
                })
            });
    }

    private void FakeCreateGroupResponse(string name)
    {
        A.CallTo(() => _graphQlClient.SendMutationAsync<CreateGroupResponse>(A<GraphQLRequest>._, default))
            .Returns(new GraphQLResponse<CreateGroupResponse>
            {
                Data = new CreateGroupResponse(new Group
                {
                    Id = _random.NextString(),
                    Name = name
                })
            });
    }

    [TestMethod]
    public async Task GetGroups_Pass()
    {
        var groupId = _random.NextUInt64();

        FakeGetGroupsResponse(groupId);

        var result = await _mondayClient.GetGroups(groupId);
        result.ShouldNotBeNull();
    }

    [TestMethod]
    public async Task UpdateItemGroup_Pass()
    {
        var itemId = _random.NextUInt64();
        var groupId = _random.NextString();

        var result = await _mondayClient.UpdateItemGroup(itemId, groupId);

        result.ShouldBeTrue();
    }

    [TestMethod]
    public async Task CreateGroup_Pass()
    {
        var boardId = _random.NextUInt64();
        var name = _random.NextString();

        FakeCreateGroupResponse(name);

        var result = await _mondayClient.CreateGroup(new CreateGroup(boardId, name));

        result.ShouldNotBeNull();
    }

    [TestMethod]
    public async Task ArchiveGroup_Pass()
    {
        var boardId = _random.NextUInt64();
        var groupId = _random.NextString();

        var result = await _mondayClient.ArchiveGroup(boardId, groupId);

        result.ShouldBeTrue();
    }

    [TestMethod]
    public async Task DeleteGroup_Pass()
    {
        var boardId = _random.NextUInt64();
        var groupId = _random.NextString();

        var result = await _mondayClient.DeleteGroup(boardId, groupId);

        result.ShouldBeTrue();
    }
}

