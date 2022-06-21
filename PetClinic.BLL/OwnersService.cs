using PetClinic.BLL.Interfaces;
using PetClinic.DAL.Interfaces;
using PetClinic.DTO;
using PetClinic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.BLL
{
    public class OwnersService : IOwnersService
    {
        private IOwnersDAO _ownersDAO;
        public OwnersService(IOwnersDAO ownersDAO)
        {
            _ownersDAO = ownersDAO;
        }
        public async Task<OwnerDTO> GetOwner(int? id)
        {
            if(id == null)
                throw new ArgumentNullException(nameof(id));

            Owner ownerFromDb = await _ownersDAO.GetOwner(id.Value);

            if (ownerFromDb == null)
                throw new Exception("Owner not found");


            OwnerDTO ownerDTO = new OwnerDTO
            {
                Id = ownerFromDb.Id,
                Name = ownerFromDb.Name,
                Surname = ownerFromDb.Surname,
                Phone = ownerFromDb.Phone
            };
            return ownerDTO;
        }

        public async Task<int> UpsertOwner(OwnerDTO ownerDTO)
        {
            if(ownerDTO == null)
                throw new ArgumentNullException(nameof(ownerDTO));

            Owner owner = new Owner
            {
                Id = ownerDTO.Id,
                Name = ownerDTO.Name,
                Surname = ownerDTO.Surname,
                Phone = ownerDTO.Phone
            };
            int idOwner = await _ownersDAO.AddOwner(owner);
            return idOwner;
        }
    }
}
