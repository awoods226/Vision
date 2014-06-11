using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vision.DataAccessLayer;

namespace Vision.Models
{
    public class TrainingEvent : ITrainingEvent
    {
        public int Id { get; set; }
        public int TrainingEventTypeId { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public int MonthInterval { get; set; }
        public int AmountRequired { get; set; }

        public virtual TrainingEventType TrainingEventType { get; set; }

        public static TrainingEvent GetById(int trainingEventId)
        {
            using (var context = new VisionContext())
            {
                return context.TrainingEvents.Where(x => x.Id == trainingEventId).FirstOrDefault();
            }
        }

    }
}