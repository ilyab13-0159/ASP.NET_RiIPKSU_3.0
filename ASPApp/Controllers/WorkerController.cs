using ASPApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {

        private readonly Worker _worker;

        public WorkerController(Worker worker)
        {
            _worker = worker;
        }

        [HttpGet("start")]
        public async Task<IActionResult> Start()
        {
            var startDate = DateTime.Now;
            await _worker.StartAsync(CancellationToken.None);
            var endDate = DateTime.Now;
            return Ok($"Worker worked {(endDate - startDate).TotalSeconds} sec");
        }
        [HttpGet("stop")]
        public async Task<IActionResult> Stop()
        {
            await _worker.StopAsync(CancellationToken.None);
            return Ok("Worker stop");

        }
    }
}
