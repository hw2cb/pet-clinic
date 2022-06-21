using PetClinic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.BLL.Interfaces
{
    public interface IOwnersService
    {
        Task<int> UpsertOwner(OwnerDTO ownerDTO);
        Task<OwnerDTO> GetOwner(int? id);

    }
}
