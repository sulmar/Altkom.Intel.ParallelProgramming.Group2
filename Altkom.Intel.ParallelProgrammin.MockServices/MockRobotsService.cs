using Altkom.Intel.ParallelProgramming.IServices;
using Altkom.Intel.ParallelProgramming.Models;
using System.Collections.Generic;
using System.Linq;

namespace Altkom.Intel.ParallelProgramming.Services.IServices
{
    public class MockRobotsService : IRobotsService
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
