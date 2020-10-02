using System;
using System.Collections.Generic;

namespace WebApp.Services
{
    public class PostFriendResult
    {
        public bool Success { get; set; }
        public List<String> Errors { get; set; }
    }
}
