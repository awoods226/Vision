using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vision.Models
{
    public class TrainingAssignment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TrainingEventId { get; set; }
        public DateTime DateAssigned { get; set; }

        public virtual ICollection<ITrainingEvent> TrainingEvents { get; set; }
    }
}