using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vision.Models
{
    public class TrainingEventType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        
        public ICollection<TrainingEvent> Events { get; set; }
    }
}