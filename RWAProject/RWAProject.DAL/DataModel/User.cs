using System;
using System.Collections.Generic;
using System.Linq;

namespace RWAProject.DAL
{
    [Serializable]
    public class User
    {
        #region Properties

        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Telephone { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
        public int CityID { get; set; }

        public bool Admin => RoleID == 2;
        public string RoleName 
            => RepositoryFacade.Repository.GetRoles().FirstOrDefault(role => role.ID == RoleID)?.Name;
        public string CityName
            => RepositoryFacade.Repository.GetCities().FirstOrDefault(city => city.ID == CityID)?.Name;

        public HashSet<PersonEmail> Emails { get; set; } = new HashSet<PersonEmail>();

        #endregion

        #region Methods

        public Person GetPerson()
            => new Person
            {
                ID = ID,
                CityID = CityID,
                Name = Name,
                Password = Password,
                RoleID = RoleID,
                Surname = Surname,
                Telephone = Telephone,
                PersonEmails = Emails
            };

        public string GetCSV() => UserFileConverter.Instance.Convert(this);

        public static User Parse(string line) => UserFileConverter.Instance.ConvertBack(line);

        public override string ToString() => $"{Name} {Surname}";

        #endregion
    }
}