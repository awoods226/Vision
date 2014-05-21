using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vision.ViewModels
{
    public class Currency
    {
        public int EventsRemaining { get; set; }
        public DateTime NextDateDue { get; set; }
        public DateTime DateLastCompleted { get; set; }
        public DateTime DateApproved { get; set; }

    }
}