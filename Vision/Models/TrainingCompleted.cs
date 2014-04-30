using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vision.Models
{
    public class TrainingCompleted
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TrainingEventId { get; set; }
        public DateTime DateCompleted { get; set; }
        public int ApprovedByUserId { get; set; }
    }
}