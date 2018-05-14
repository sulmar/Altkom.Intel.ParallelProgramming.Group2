using Altkom.Intel.ParallelProgramming.IServices;
using Altkom.Intel.ParallelProgramming.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Altkom.Intel.ParallelProgramming.Services.IServices
{
    public class MockRobotsService : IRobotsService
    {
        private IList<Robot> robots = new List<Robot>
        {
            new Robot { Id = 1, Name = "Robot 1", SuppportedActions = ActionType.Move | ActionType.Wait },
            new Robot { Id = 2, Name = "Robot 2", SuppportedActions = ActionType.Move | ActionType.Terminate },
            new Robot { Id = 3, Name = "Robot 3", SuppportedActions = ActionType.Move | ActionType.Wait | ActionType.Terminate },
        };
       

        public void Add(Robot robot)
        {
            if (!robot.SuppportedActions.HasFlag(ActionType.Move))
            {
                throw new NotSupportedException();
            }

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
