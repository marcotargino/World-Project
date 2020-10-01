using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

            return Ok(list); //200
        }

        // GET api/<FriendsController>/5
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            var response = SearchFriendById(id);

            if (response == null)
            {
                return NotFound(); //404
            }
            else
            {
                return Ok(response); //200
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
            var errors = friendRequest.Errors();

            if (errors.Any())
            {
                return UnprocessableEntity(errors); //422
            }

            var response = CreateFriend(friendRequest);

            return CreatedAtAction(nameof(Get), new { response.Id }, response); //201
        }

        private FriendResponse CreateFriend(FriendRequest friendRequest)
        {
            throw new NotImplementedException();
        }

        // PUT api/<FriendsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] FriendRequest request)
        {
            var response = SearchFriendById(id);

            if (response == null)
            {
                return NotFound(); //404
            }
            else
            {
                ModifyFriend(request);
                return NoContent(); //204
            }
        }

        private void ModifyFriend(FriendRequest request)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<FriendsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var response = SearchFriendById(id);

            if (response == null)
            {
                return NotFound(); //404
            }
            else
            {
                RemoveFriend(id);
                return NoContent(); //204
            }
        }

        private void RemoveFriend(string id)
        {
            throw new NotImplementedException();
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

        internal List<string> Errors()
        {
            throw new NotImplementedException();
        }
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
