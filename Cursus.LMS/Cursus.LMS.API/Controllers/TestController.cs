using System.Security.Claims;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.Hubs;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Service.Service;
using Cursus.LMS.Utility.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Task = DocumentFormat.OpenXml.Office2021.DocumentTasks.Task;

namespace Cursus.LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IFirebaseService _firebaseService;
        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;
        private readonly IHubContext<NotificationHub> _hubContext;

        public TestController(IFirebaseService firebaseService, IAuthService authService, ITokenService tokenService,
            IHubContext<NotificationHub> hubContext)
        {
            _firebaseService = firebaseService;
            _authService = authService;
            _tokenService = tokenService;
            _hubContext = hubContext;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendSignalR(string userId)
        {
            await _hubContext.Clients.User(userId).SendAsync("ReceiveMessage", "Hello");
            return Ok();
        }
    }
}