﻿using Monday.Client.Models;
using Monday.Client.Options;
using System.Collections.Generic;

namespace Monday.Client.Requests
{
    public interface IGetUsersRequest : IMondayRequest
    {
        UserAccessTypes? UserAccessType { get; set; }

        IUserOptions UserOptions { get; set; }
    }

    public interface IGetUsersResult : IMondayResult
    { 
        IEnumerable<User> Data { get; } 
    }

    internal class GetUsersResult : MondayResult, IGetUsersResult
    {
        public IEnumerable<User> Data { get; set;  }

        public GetUsersResult(IEnumerable<User> data)
        {
            Data = data;
        }
    }

    public class GetUsersRequest : MondayRequest, IGetUsersRequest
    {
        public UserAccessTypes? UserAccessType { get; set; } = null;

        public IUserOptions UserOptions { get; set; }

        public GetUsersRequest()
        {
            UserOptions = new UserOptions(RequestMode.Default);
        }

        public GetUsersRequest(RequestMode mode)
        {
            UserOptions = new UserOptions(mode);
        }
    }
}
