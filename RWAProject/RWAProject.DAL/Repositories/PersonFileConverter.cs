namespace RWAProject.DAL {
    class PersonFileConverter : BaseFileConverter<PersonFileConverter, Person> {
        public override string Convert(Person person)
            => string.Join(Separator,
                person.ID,
                person.Name,
                person.Surname,
                person.Telephone,
                person.Password,
                person.RoleID,
                person.CityID
            );

        public override Person ConvertBack(string line) {
            var data = line?.Split(new string[] { Separator }, System.StringSplitOptions.None);

            if (data == null || data.Length != 7)
                return null;

            if (!(
                int.TryParse(data[0], out int id) &&
                int.TryParse(data[5], out int roleID) &&
                int.TryParse(data[6], out int cityID)
            ))
                return null;

            return new Person {
                ID = id,
                Name = data[1],
                Surname = data[2],
                Telephone = data[3],
                Password = data[4],
                RoleID = roleID,
                CityID = cityID
            };
        }
    }
    }
