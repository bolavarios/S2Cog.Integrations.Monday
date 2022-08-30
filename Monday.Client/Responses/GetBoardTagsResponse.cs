using Monday.Client.Models;
using System.Collections.Generic;

namespace Monday.Client.Responses;

public class GetBoardTagsResponse
{
    public IEnumerable<Board> Boards { get; set; }

    public GetBoardTagsResponse(IEnumerable<Board> boards)
    {
        Boards = boards;
    }
}