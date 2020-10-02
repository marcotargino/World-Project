using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Friends.Resources.FriendResource;

namespace WebApi_Friends.AutomapperProfiles
{
    public class FriendProfile : Profile
    {
        public FriendProfile()
        {
            CreateMap<Friend, FriendResponse>();
        }
    }
}
