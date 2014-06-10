using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Vision.Models;

namespace Vision.ViewModels
{
    public class Currency
    {
        [Display(Name = "Events Remaining")]
        public int EventsRemaining { get; set; }
        
        [Display(Name= "Next Date Due")]
        public DateTime NextDateDue { get; set; }
        
        [Display(Name = "Date Last Completed")]
        public DateTime DateLastCompleted { get; set; }
        
        [Display(Name = "Date Approved")]
        public DateTime DateApproved { get; set; }

        [Display(Name= "Event Name")]
        public string EventName { get; set; }

        public static IEnumerable<Currency> RetrieveCurrencyForUser(string userId)
        {
            List<Currency> currencyList = new List<Currency>();
            //retrieve all events user has assigned
            var assignments = TrainingAssignment.GetAssignedTrainingForUser(userId);
            //retrieve all completed trainingEvents
            var completed = TrainingCompleted.GetCompletedEventsForUserId(userId);
            foreach (var tEvent in assignments)
            {
                var completedFiltered = completed.Where(x => x.TrainingEventId == tEvent.TrainingEventId);
                currencyList.Add(Calculate(tEvent.TrainingEventId, completedFiltered));
            }
            return currencyList;
            
        }

        private static Currency Calculate(int trainingEventId, IEnumerable<TrainingCompleted> completedEvents)
        {
            return null;
        }


    }
}