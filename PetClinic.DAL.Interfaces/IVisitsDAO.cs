using PetClinic.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetClinic.DAL.Interfaces
{
    public interface IVisitsDAO
    {
        Task AddVisit(Visit visit);
        Task<IEnumerable<Visit>> GetVisits();
        Task<IEnumerable<Visit>> GetVisitsFilter(string vetId,DateTime startDate, DateTime endDate);
        Task<Visit> GetVisit(int id);

    }
}
