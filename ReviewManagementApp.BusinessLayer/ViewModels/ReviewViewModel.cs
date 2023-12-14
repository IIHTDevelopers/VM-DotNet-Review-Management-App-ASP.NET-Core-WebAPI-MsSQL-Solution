using System;
using System.Collections.Generic;
using System.Text;

namespace ReviewManagementApp.BusinessLayer.ViewModels
{
    public class ReviewViewModel
    {
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public DateTime SubmissionDate { get; set; }
    }
}
