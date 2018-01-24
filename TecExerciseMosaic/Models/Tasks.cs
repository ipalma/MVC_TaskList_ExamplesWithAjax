using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TecExerciseMosaic.Models
{
    public class Tasks
    {
        public int TaskId { get; set; }
        public bool Selected { get; set; }
        public string Description { get; set; }

    }
}