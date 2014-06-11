using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Vision.Models;
using System.ComponentModel;


namespace Vision.ViewModels
{
   
    public enum CurrencyStatus
    {
        [Description("Current")]
        Current = 1,
        [Description("Non-Current")]
        NonCurrent = 2,
        [Description("Unqualified")]
        Unqualified = 3
    };
    public static class CurrencyStatusExtensions
    {
        public static string ToFriendlyString(this CurrencyStatus me)
        {
            switch (me)
            {
                case CurrencyStatus.Current:
                    return "Current";
                case CurrencyStatus.NonCurrent:
                    return "Non-Current";
                case CurrencyStatus.Unqualified:
                    return "Unqualified";
            }
            return null;
        }
    }
    public class Currency
    {   
        [Display(Name= "Next Date Due")]
        public string NextDateDue { get; set; }
        
        [Display(Name = "Date Last Completed")]
        public string DateLastCompleted { get; set; }
        
        [Display(Name= "Event Name")]
        public string EventName { get; set; }

        [Display(Name = "Status")]
        public string currencyStatus { get; set; }

        [Display(Name = "Completed")]
        public int AmountAccomplished { get; set; }

        [Display(Name = "Remaining")]
        public int AmountRemaining { get; set; }

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

        /// <summary>
        /// Calculates currency status of a single event
        /// It is important to keep this event as simple as possible as currency calculations can grow to become really complicated if we let them
        /// Remember to aggressively refactor this method
        /// </summary>
        /// <param name="trainingEventId"></param>
        /// <param name="completedEvents"></param>
        /// <returns></returns>
        private static Currency Calculate(int trainingEventId, IEnumerable<TrainingCompleted> completedEvents)
        {
            //initialize Currency event
            Currency currency = new Currency();
            CurrencyStatus eventStatus = new CurrencyStatus();

            //retrieve information about event so we know how to calculate it
            var trainingEvent = TrainingEvent.GetById(trainingEventId);
            if (trainingEvent == null)
            {
                return null;
            }

            //NOTE:  Currently running into an issue where it is displaying non-current even though their currency period is not up yet... figure out how to calculate this in a simple way

            currency.EventName = trainingEvent.Name;
            currency.DateLastCompleted = completedEvents.Max(x => x.DateCompleted).ToShortDateString();
            currency.NextDateDue = completedEvents.Max(x => x.DateCompleted).AddMonths(trainingEvent.MonthInterval).ToShortDateString();
            
            //see if they have completed the required amount of events in the given time period
            var completedAmount = completedEvents.Where(x => x.DateCompleted >= DateTime.Now.AddMonths(-trainingEvent.MonthInterval)).Count();

            if (completedAmount >= trainingEvent.AmountRequired) eventStatus = CurrencyStatus.Current;
            else eventStatus = CurrencyStatus.NonCurrent;

            currency.AmountRemaining = trainingEvent.AmountRequired - completedAmount;
            if (currency.AmountRemaining < 0) currency.AmountRemaining = 0;

            currency.currencyStatus = CurrencyStatusExtensions.ToFriendlyString(eventStatus);

            return currency;
        }


    }
}