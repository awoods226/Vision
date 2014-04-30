using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vision.Models
{
    public class Division
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TrainingTable> TraingTables { get; set; }
    }
}