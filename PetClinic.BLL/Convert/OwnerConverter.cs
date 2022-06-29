using PetClinic.DTO;
using PetClinic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.BLL.Convert
{
    public static class OwnerConverter
    {
        public static OwnerDTO ConvertToDTO(Owner owner)
        {
            OwnerDTO ownerDTO = new OwnerDTO
            {
                Id = owner.Id,
                Name = owner.Name,
                Surname = owner.Surname,
                Phone = owner.Phone
            };
            return ownerDTO;
        }
        public static Owner ConvertFromDTO(OwnerDTO ownerDTO)
        {
            Owner owner = new Owner
            {
                Id = ownerDTO.Id,
                Name = ownerDTO.Name,
                Surname = ownerDTO.Surname,
                Phone = ownerDTO.Phone
            };
            return owner;
        }
    }
}
