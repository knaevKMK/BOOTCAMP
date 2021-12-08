using CarShop.Data;
using CarShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarShop.Services
{
    public class IssuesService : IIssuesService
    {
        private readonly ApplicationDbContext data;

        public IssuesService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public string Create(Issue issue)
        {
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Issue> entityEntry = data.Issues.Add(issue);
            data.SaveChanges();
            return entityEntry.Entity.Id;
        }

        public string Delete(string id)
        {
            Issue issue = data.Issues.FirstOrDefault(e => e.Id == id );
            if (issue==null)
            {
                return null;
            }
            data.Issues.Remove(issue);
            data.SaveChanges();
            return issue.CarId;
        }

        public string Fix(string id)
        {
            Issue issue = data.Issues.FirstOrDefault(e => e.Id == id );
            if (issue == null)
            {
                return null;
            }
            issue.isFixed = true;
            data.SaveChanges();
            return issue.CarId;
        }

        public ICollection<Issue> getAll(string carId)
        {
            return data.Issues
                .Where(e => e.CarId == carId)
                .ToList();
        }
    }
}
