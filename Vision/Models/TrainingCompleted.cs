using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vision.DataAccessLayer;

namespace Vision.Models
{
    public class TrainingCompleted
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int TrainingEventId { get; set; }
        public DateTime DateCompleted { get; set; }
        public string ApprovedByUserId { get; set; }

        public virtual TrainingEvent TrainingEvent { get; set; }

        public static IEnumerable<TrainingCompleted> GetCompletedEventsForUserId(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return null;
            }
            using (var context = new VisionContext())
            {
                return context.TrainingCompleted.Where(x => x.UserId == userId).ToList();
            }
        }
    }
}