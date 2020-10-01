using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi_Friends.Resources.FriendResource;

namespace WebApi_Friends.Data
{
    public class WebApi_FriendsContext : DbContext
    {
        public WebApi_FriendsContext (DbContextOptions<WebApi_FriendsContext> options)
            : base(options)
        {
        }

        public DbSet<WebApi_Friends.Resources.FriendResource.FriendResponse> FriendResponse { get; set; }
    }
}
