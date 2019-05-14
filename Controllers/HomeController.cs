using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRChat.Hubs;

namespace signalrbuttondemo.Controllers
{
    public class HomeController : Controller
    {
        private static int _count = 0;
        private readonly IHubContext<ButtonCounterHub> _hubContext;

        public HomeController(IHubContext<ButtonCounterHub> hubContext)
        {
            this._hubContext = hubContext;
        }

        [HttpPost("/increment")]
        public async Task<IActionResult> Increment()
        {
            await _hubContext.Clients.All.SendAsync("ReceiveCount", ++_count);
            return Ok();
        }
    }
}
