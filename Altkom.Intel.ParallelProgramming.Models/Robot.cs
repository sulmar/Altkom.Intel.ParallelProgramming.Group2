using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Altkom.Intel.ParallelProgramming.Models
{
    public class Robot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<ActionType> SuppportedActions { get; set; }
    }

    public enum ActionType
    {
        Terminate,
        Move,
        Wait
    }
}