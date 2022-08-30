﻿using Monday.Client.Models;

namespace Monday.Client.Responses
{
    public class GetComplexityResponse
    {
        public Complexity Complexity { get; set; }
    
        public GetComplexityResponse(Complexity complexity)
        {
            Complexity = complexity;
        }
    }
}