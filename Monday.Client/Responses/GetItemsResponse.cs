using System.Collections.Generic;
using Monday.Client.Models;

namespace Monday.Client.Responses
{
    public class GetItemsResponse
    {
        public IEnumerable<Item> Items { get; set; }

        public GetItemsResponse(IEnumerable<Item> items)
        {
            Items = items;
        }
    }
}