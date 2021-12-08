using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.ViewModels.Issue
{
public    class IssueViewModel
    {
        public string Id { get; set; }
        public bool isFixed { get; set; }
        public string Description { get; set; }
        public string CarId { get; set; }
    }
}
