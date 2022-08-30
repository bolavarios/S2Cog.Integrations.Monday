using System;
using System.Collections.Generic;
using Monday.Client.Models;

namespace Monday.Client.Responses
{
    public class GetUsersResponse
    {
        public IEnumerable<User> Users { get; set; } = Array.Empty<User>();
    }
}