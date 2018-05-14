using Altkom.Intel.ParallelProgramming.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Intel.ParallelProgramming.IServices
{
    public interface IRobotsService
    {
        void Add(Robot robot);

        IList<Robot> Get();

        void Remove(int id);
    }
}
