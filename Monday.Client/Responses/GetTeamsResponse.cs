using System.Collections.Generic;
using Monday.Client.Models;

namespace Monday.Client.Responses
{
    public class GetTeamsResponse
    {
        public IEnumerable<Team> Teams { get; set; }
    
        public GetTeamsResponse(IEnumerable<Team> teams)
        {
            Teams = teams;
        }
    }
}