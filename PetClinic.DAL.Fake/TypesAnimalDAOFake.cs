using PetClinic.DAL.Interfaces;
using PetClinic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.DAL.Fake
{
    public class TypesAnimalDAOFake //: ITypesAnimalDAO
    {
        private static List<TypeAnimal> _typesAnimal;
        public TypesAnimalDAOFake()
        {
            #region FAKE DATA
            TypeAnimal type1 = new TypeAnimal
            {
                Id = 1,
                Type = "Dog"
            };
            TypeAnimal type2 = new TypeAnimal
            {
                Id = 2,
                Type = "Cat"
            };
            TypeAnimal type3 = new TypeAnimal
            {
                Id = 3,
                Type = "Parrot"
            };

            _typesAnimal = new List<TypeAnimal>();
            _typesAnimal.Add(type1);
            _typesAnimal.Add(type2);
            _typesAnimal.Add(type3);
            #endregion
        }
        public void AddAnimalType(TypeAnimal type)
        {
            if (type == null)
                throw new ArgumentNullException("type is null");

            _typesAnimal.Add(type);
        }

        public TypeAnimal GetTypeAnimal(int id)
        {
            return _typesAnimal.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<TypeAnimal> GetTypesAnimal()
        {
            return _typesAnimal;
        }
    }
}
