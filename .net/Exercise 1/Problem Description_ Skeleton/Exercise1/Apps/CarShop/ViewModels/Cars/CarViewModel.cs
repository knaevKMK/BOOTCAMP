using CarShop.ViewModels.Issue;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.ViewModels.Cars
{
   public class CarViewModel
    {
        public string Id { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string ImageUrl { get; set; }
        public string PlateNumber { get; set; }
        public int FixedUssues { get; set; }
        public int RemainingUssues { get; set; }
        public ICollection<IssueViewModel> Issues { get; set; }
    }
}
