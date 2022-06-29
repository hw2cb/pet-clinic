using PetClinic.BLL.Convert;
using PetClinic.BLL.Interfaces;
using PetClinic.DAL.Interfaces;
using PetClinic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.BLL
{
    public class VisitsService : IVisitsService
    {
        private IVisitsDAO _visitsDAO;
        private IAnimalsService _animalsService;
        public VisitsService(IVisitsDAO visitsDAO, IAnimalsService animalService)
        {
            _visitsDAO = visitsDAO;
            _animalsService = animalService;
        }
        public async Task<IEnumerable<VisitDTO>> GetVisitsToDay(string vetId)
        {
            if (string.IsNullOrEmpty(vetId))
                throw new ArgumentNullException("vet id is null");

            DateTime dateTimeStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            DateTime dateTimeEnd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 0);
            var visitsFromDB = await _visitsDAO.GetVisitsFilter(vetId, dateTimeStart, dateTimeEnd);
            List<VisitDTO> visits = new List<VisitDTO>();
            
            //TODO: AutoMapper
            for(int i=0; i < visitsFromDB.Count(); i++)
            {
                var visitDTO = VisitConverter.ConvertToDTO(visitsFromDB.ElementAt(i));
                
                visits.Add(visitDTO);

            }
            return visits;
        }
    }
}
