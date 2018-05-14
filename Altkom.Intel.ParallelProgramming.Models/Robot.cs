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
        public ActionType SuppportedActions { get; set; }
    }

    [Flags]
    public enum ActionType
    {
        Terminate = 1,
        Move = 2,
        Wait = 4
    }
}