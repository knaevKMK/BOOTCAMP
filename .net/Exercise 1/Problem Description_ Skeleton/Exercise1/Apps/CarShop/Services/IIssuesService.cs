using CarShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarShop.Services
{
    public interface IIssuesService
    {
        ICollection<Issue> getAll(string carId);
        string Create(Issue issue);
        string Delete(string id);
        string Fix(string id);
    }
}
