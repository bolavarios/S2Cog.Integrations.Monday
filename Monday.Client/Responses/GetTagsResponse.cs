using System.Collections.Generic;
using Monday.Client.Models;

namespace Monday.Client.Responses
{
    public class GetTagsResponse
    {
        public IEnumerable<Tag> Tags { get; set; }

        public GetTagsResponse(IEnumerable<Tag> tags)
        {
            Tags = tags;
        }
    }
}