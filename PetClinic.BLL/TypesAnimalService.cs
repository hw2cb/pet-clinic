using PetClinic.BLL.Interfaces;
using PetClinic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetClinic.DAL.Interfaces;
using PetClinic.BLL.Convert;

namespace PetClinic.BLL
{
    public class TypesAnimalService : ITypesAnimalService
    {
        private ITypesAnimalDAO _typesAnimalDAO;
        public TypesAnimalService(ITypesAnimalDAO typesAnimalDAO)
        {
            _typesAnimalDAO = typesAnimalDAO;
        }
        public async Task<IEnumerable<TypeAnimalDTO>> GetTypesAnimal()
        {
            var typesAnimalFromDB = await _typesAnimalDAO.GetTypesAnimal();

            List<TypeAnimalDTO> typesAnimalDTO = new List<TypeAnimalDTO>();

            for(int i=0; i<typesAnimalFromDB.Count(); i++)
            {
                typesAnimalDTO.Add(TypeAnimalConverter.ConvertToDTO(typesAnimalFromDB.ElementAt(i)));
            }
            return typesAnimalDTO;
        }
    }
}
