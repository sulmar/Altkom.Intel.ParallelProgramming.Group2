using Altkom.Intel.ParallelProgramming.IServices;
using Altkom.Intel.ParallelProgramming.Models;
using Altkom.Intel.ParallelProgramming.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Altkom.Intel.ParallelProgramming.Service.Controllers
{
    public class RobotsController : ApiController
    {
        // tylko pokazowo
        private static IRobotsService robotsService = new MockRobotsService();

        //public RobotsController(IRobotsService robotsService)
        //{
        //    this.robotsService = robotsService;
        //}

        //public RobotsController()
        //    : this(new MockRobotsService())
        //{

        //}

        public async Task<IHttpActionResult> Get()
        {
            var robots = await robotsService.GetAsync();

            return Ok(robots);
        }

        public IHttpActionResult Post(Robot robot)
        {
            robotsService.Add(robot);

            // return Created($"api/robots/{robot.Id}", robot);

            return CreatedAtRoute("DefaultApi", new { id = robot.Id }, robot);
        }
    }
}