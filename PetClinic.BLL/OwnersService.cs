using PetClinic.BLL.Convert;
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

            return OwnerConverter.ConvertToDTO(ownerFromDb);
        }

        public async Task<int> UpsertOwner(OwnerDTO ownerDTO)
        {
            if(ownerDTO == null)
                throw new ArgumentNullException(nameof(ownerDTO));

            Owner owner = OwnerConverter.ConvertFromDTO(ownerDTO);

            int idOwner = await _ownersDAO.AddOwner(owner);
            return idOwner;
        }
    }
}
