using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPIProtection;
using SignalRChat.Helpers;
using SignalRChat.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChat.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class testcontroller : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<testcontroller> _logger;
        public readonly PSRun _runMe;
        public ChatHub _chathub;

        public testcontroller(ILogger<testcontroller> logger, PSRun psrun, ChatHub chatHub)
        {
            _logger = logger;
            _chathub = chatHub;
            _runMe = psrun;
        }
        
        [HttpGet]
        public async Task Get1()
        {   
            _runMe.StartPS();
        }
       
        [HttpGet("{vm}")]
        public async Task<string>Get2([FromQuery] string Command)
        {
            var res = _runMe.StartPSArg(Command);
            return (res);
        }

        /*
        [HttpGet("{vm}")]
        public async Task Get2([FromQuery] string Command)
        {
            //_runMe.StartPSArg(Command);
            _runMe.StartPSArg_old(Command);

        }
        */
    }
}