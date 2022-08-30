using Monday.Client.Models;
using System.Collections.Generic;

namespace Monday.Client.Responses;

public class GetBoardItemsResponse
{
    public IEnumerable<Board> Boards { get; set; }

    public GetBoardItemsResponse(IEnumerable<Board> boards)
    {
        Boards = boards;
    }
}