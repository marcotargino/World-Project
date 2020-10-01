using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace WebApi_Friends.Resources.FriendResource
{
    [ApiController]
    [Route("api/friends")]
    public class FriendsController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            var list = new List<FriendResponse>();

            return Ok(list);
        }

        // GET api/<FriendsController>/5
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            var response = SearchFriendById(id);

            if (response == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(response);
            }
        }

        private object SearchFriendById(string id)
        {
            throw new NotImplementedException();
        }

        // POST api/<FriendsController>
        [HttpPost]
        public ActionResult Post([FromBody] FriendRequest friendRequest)
        {
            var response = CreateFriend(friendRequest);

            return CreatedAtAction(nameof(Get), new { response.Id }, response);
        }

        private FriendResponse CreateFriend(FriendRequest friendRequest)
        {
            throw new NotImplementedException();
        }

        // PUT api/<FriendsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FriendsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
        }
    }

    public class FriendRequest
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public String ProfilePicture { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }
        public String Country { get; set; }
        public String State { get; set; }
    }

    public class FriendResponse
    {
        public Guid Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public String ProfilePicture { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }
        public String Country { get; set; }
        public String State { get; set; }
    }
}
