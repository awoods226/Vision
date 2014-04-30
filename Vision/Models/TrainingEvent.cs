using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vision.Models
{
    public class TrainingEvent : ITrainingEvent
    {
        public int Id { get; set; }
        public int TrainingEventTypeId { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public int MonthInterval { get; set; }

        public virtual TrainingEventType TrainingEventType { get; set; }
    }
}