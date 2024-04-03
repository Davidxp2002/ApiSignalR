using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSignalrBG.Hubs;
using ApiSignalrBG.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ApiSignalrBG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcesoController : ControllerBase
    {

        private readonly IHubContext<Proceso> _hubContext;

        public ProcesoController(IHubContext<Proceso> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        [Route("iniciar")]
        public IActionResult IniciarProceso([FromBody] Id idSignalR)
        {
            _ = Task.Run(async () =>
            {
                
                await Task.Delay(TimeSpan.FromSeconds(5));
                await _hubContext.Clients.Client(idSignalR.IdSignalR).SendAsync("proceso", true);
            });
            return Ok(new { mensaje = "Hola..."});

        }

        [HttpPost]
        [Route("Cambie esto")]
        public IActionResult IniciarProceso2([FromBody] Id idSignalR)
        {
            _ = Task.Run(async () =>
            {

                await Task.Delay(TimeSpan.FromSeconds(5));
                await _hubContext.Clients.Client(idSignalR.IdSignalR).SendAsync("proceso", true);
            });
            return Ok(new { mensaje = "Hola..." });

        }

         [HttpPost]
        [Route("iniciar6")]
        public IActionResult IniciarProceso4([FromBody] Id idSignalR)
        {
            _ = Task.Run(async () =>
            {

                await Task.Delay(TimeSpan.FromSeconds(5));
                await _hubContext.Clients.Client(idSignalR.IdSignalR).SendAsync("proceso", true);
            });
            return Ok(new { mensaje = "Hola..." });

        }

    }
}

