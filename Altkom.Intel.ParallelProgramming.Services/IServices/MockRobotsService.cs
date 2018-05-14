using Altkom.Intel.ParallelProgramming.Service.Models;
using System.Collections.Generic;

namespace Altkom.Intel.ParallelProgramming.Services.IServices
{
    class MockRobotsService : IRobotsService
    {
        private IList<Robot> robots = new List<Robot>();

        public void Add(Robot robot)
        {
            robots.Add(robot);
        }

        public IList<Robot> Get()
        {
            return robots;
        }

        private Robot Get(int id)
        {
            return robots.SingleOrDefault(r => r.Id == id);
        }

        public void Remove(int id)
        {
            var robot = Get(id);

            robots.Remove(robot);
        }
    }
}
