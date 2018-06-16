using System.Collections.Generic;
using System.Linq;

namespace RWAProject.DAL
{
    class DatabaseRepository : IRepository
    {
        #region Create

        public bool AddUser(User user)
        {
            using (var model = new DataModel())
            {
                var person = user.GetPerson();

                model.People.Add(person);

                try
                {
                    var saved = model.SaveChanges() > 0;

                    if (saved)
                    {
                        user.ID = person.ID;

                        return true;
                    }

                    return false;
                }
                catch (System.Exception ex) { return false; }
            }
        }

        public bool AddEmail(User user, string email)
        {
            using (var model = new DataModel())
            {
                var mail = new PersonEmail
                {
                    Email = email,
                    PersonID = user.ID
                };

                model.PersonEmails.Add(mail);
                user.Emails.Add(mail);

                try { return model.SaveChanges() > 0; }
                catch (System.Exception ex) { return false; }
            }
        }

        #endregion

        #region Retreive

        public IEnumerable<City> GetCities()
        {
            using (var model = new DataModel())
                return new List<City>(model.Cities);
        }

        public IEnumerable<Role> GetRoles()
        {
            using (var model = new DataModel())
                return new List<Role>(model.Roles);
        }

        public IEnumerable<User> GetUsers()
        {
            using (var model = new DataModel())
            {
                var users = model.People.Select(person => new User
                {
                    ID = person.ID,
                    Name = person.Name,
                    Surname = person.Surname,
                    Telephone = person.Telephone,
                    Password = person.Password,
                    CityID = person.CityID,
                    RoleID = person.RoleID
                }).ToList();

                foreach (var email in model.PersonEmails)
                {
                    for (int i = 0; i < users.Count; i++)
                    {
                        if (users[i].ID == email.PersonID)
                        {
                            users[i].Emails.Add(email);
                            break;
                        }
                    }
                }

                return users;
            }
        }

        public IEnumerable<User> GetUsersByEmail(string email)
            => GetUsers().Where(user => user.Emails.Any(mail => mail.Email == email));

        public User Login(string username, string password)
        {
            foreach (var user in GetUsersByEmail(username))
                if (user.Password == password)
                    return user;

            return null;
        }

        #endregion

        #region Update

        public bool UpdateUser(User user)
        {
            using (var model = new DataModel())
            {
                var person = model.People.Find(user.ID);

                if (person == null)
                    return false;

                person.Name = user.Name;
                person.Surname = user.Surname;
                person.Password = user.Password;
                person.Telephone = user.Telephone;
                person.RoleID = user.RoleID;
                person.CityID = user.CityID;

                foreach (var email in user.Emails) {
                    var dbEmail = model.PersonEmails.Find(email.ID);

                    if (dbEmail == null)
                        model.PersonEmails.Add(email);
                    else 
                        dbEmail.Email = email.Email;
                }

                try { return model.SaveChanges() > 0; }
                catch (System.Exception ex) { return false; }
            }
        }

        #endregion

        #region Delete

        public bool RemoveUser(User user)
        {
            using (var model = new DataModel())
            {
                var personToRemove = model.People.Find(user.ID);

                if (personToRemove == null)
                    return false;

                model.People.Remove(personToRemove);
                model.PersonEmails.RemoveRange(model.PersonEmails.Where(email => email.PersonID == user.ID));

                try { return model.SaveChanges() > 0; }
                catch (System.Exception) { return false; }
            }
        }

        #endregion
    }
}
