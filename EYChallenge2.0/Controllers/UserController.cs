﻿using EYChallenge2._0.Data.Interfaces;
using EYChallenge2._0.Models;
using EYChallenge2._0.ViewModel.User;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EYChallenge2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }



        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userRepository.GetAll();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public User Get(string id)
        {
            return _userRepository.GetById(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] InsertuserViewModel user)
        {
            User Nuser = new User();
            Nuser.name = user.name;
            Nuser.email = user.email;
            Nuser.password = user.password;
            
            
            _userRepository.Add(Nuser);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] User user)
        {
            _userRepository.Update(id, user);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _userRepository.Delete(id);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("Disable/{id}")]
        public void Disable(string id)
        {
            _userRepository.disable(id);
        }

    }
}