using PetClinic.DAL.Interfaces;
using PetClinic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.DAL.Fake
{
    public class OwnersDAOFake //: IOwnersDAO
    {
        private static List<Owner> _owners;
        public OwnersDAOFake()
        {
            #region FAKE DATA
            Owner owner1 = new Owner
            {
                Id = 1,
                Surname = "Smith",
                Name = "Alex",
                Phone = "063-145-90"
            };

            Owner owner2 = new Owner
            {
                Id = 2,
                Surname = "Montemagno",
                Name = "John",
                Phone = "066-134-65"
            };
            Owner owner3 = new Owner
            {
                Id = 3,
                Surname = "Doil",
                Name = "Sam",
                Phone = "063-206-76"
            };
            Owner owner4 = new Owner
            {
                Id = 4,
                Surname = "Goody",
                Name = "Anton",
                Phone = "063-201-87"
            };

            _owners = new List<Owner>();
            _owners.Add(owner1);
            _owners.Add(owner2);
            _owners.Add(owner3);
            _owners.Add(owner4);
            #endregion
        }
        public void AddOwner(Owner owner)
        {
            if (owner == null)
                throw new ArgumentNullException("owner is null");

            _owners.Add(owner);
        }

        public int GetLastIdentity()
        {
            if (_owners.Count == 0)
                return 0;

            return _owners.LastOrDefault().Id;
        }

        public Owner GetOwner(int? id)
        {
            return _owners.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Owner> GetOwners()
        {
            return _owners;
        }
    }
}
