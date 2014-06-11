using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vision.DataAccessLayer;

namespace Vision.Models
{
    public class TrainingAssignment
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int TrainingEventId { get; set; }
        public DateTime DateAssigned { get; set; }

        public virtual ICollection<ITrainingEvent> TrainingEvents { get; set; }

        public static IEnumerable<TrainingAssignment> GetAssignedTrainingForUser(string userId)
        {
            using (var context = new VisionContext())
            {
                if (string.IsNullOrEmpty(userId))
                {
                    return null;
                }
                return context.TrainingAssignments.Where(x => x.UserId == userId).ToList();
            }
        }
    }
}