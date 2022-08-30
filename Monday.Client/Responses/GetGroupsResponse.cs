using Monday.Client.Models;
using System.Collections.Generic;

namespace Monday.Client.Responses;

public class GetGroupsResponse
{
    public IEnumerable<Board> Boards { get; set; }

    public GetGroupsResponse(IEnumerable<Board> boards)
    {
        Boards = boards;
    }
}