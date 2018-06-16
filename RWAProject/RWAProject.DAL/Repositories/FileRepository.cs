using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RWAProject.DAL
{
    class FileRepository : IRepository
    {
        #region Fields

        private readonly string peopleDataPath;
        private readonly string citiesDataPath;
        private readonly string rolesDataPath;

        #endregion

        #region Constructor

        public FileRepository()
        {
            string directory = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                "RWA Webforms"
            );

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            peopleDataPath = Path.Combine(directory, "People.txt");
            citiesDataPath = Path.Combine(directory, "Cities.txt");
            rolesDataPath = Path.Combine(directory, "Roles.txt");

            var dbRepo = new DatabaseRepository();
            if (!File.Exists(peopleDataPath))
                File.WriteAllLines(peopleDataPath, dbRepo.GetUsers().Select(user => UserFileConverter.Instance.Convert(user)));

            if (!File.Exists(citiesDataPath))
                File.WriteAllLines(citiesDataPath, dbRepo.GetCities().Select(city => CityFileConverter.Instance.Convert(city)));

            if (!File.Exists(rolesDataPath))
                File.WriteAllLines(rolesDataPath, dbRepo.GetRoles().Select(role => RoleFileConverter.Instance.Convert(role)));
        }

        #endregion

        #region Create

        public bool AddUser(User user)
        {
            try
            {
                var users = GetUsers().ToList();

                user.ID = users.Count == 0 ? 1 : users.Max(u => u.ID) + 1;

                foreach (var email in user.Emails)
                    email.PersonID = user.ID;

                users.Add(user);
                SaveUsers(users);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddEmail(User user, string email)
        {
            try
            {
                var users = GetUsers().ToList();

                for (int i = 0; i < users.Count; i++)
                    if (users[i].ID == user.ID)
                    {
                        var mail = new PersonEmail
                        {
                            PersonID = user.ID,
                            Email = email
                        };

                        users[i].Emails.Add(mail);
                        user.Emails.Add(mail);
                        SaveUsers(users);
                        return true;
                    }
            }
            catch (Exception ex)
            {
            }

            return false;
        }

        #endregion

        #region Retreive

        public IEnumerable<User> GetUsersByEmail(string email)
        {
            try
            {
                return GetUsers().Where(user => user.Emails.Any(mail => mail.Email == email));
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<User> GetUsers()
        {
            try
            {
                return GetLines(peopleDataPath)
                        .Select(line => UserFileConverter.Instance.ConvertBack(line))
                        .Where(user => user != null);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<City> GetCities()
        {
            try
            {
                return GetLines(citiesDataPath)
                        .Select(line => CityFileConverter.Instance.ConvertBack(line))
                        .Where(city => city != null);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<Role> GetRoles()
        {
            try
            {
                return GetLines(rolesDataPath)
                        .Select(line => RoleFileConverter.Instance.ConvertBack(line))
                        .Where(role => role != null);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public User Login(string username, string password)
        {
            try
            {
                return GetUsersByEmail(username).FirstOrDefault(user => user.Password == password);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region Update

        public bool UpdateUser(User user)
        {
            try
            {
                var users = GetUsers().ToList();

                for (int i = 0; i < users.Count; i++)
                    if (users[i].ID == user.ID)
                    {
                        users[i] = user;
                        SaveUsers(users);
                        return true;
                    }
            }
            catch (Exception ex)
            {
            }

            return false;
        }

        #endregion

        #region Delete

        public bool RemoveUser(User user)
        {
            try
            {
                var users = GetUsers().ToList();

                for (int i = 0; i < users.Count; i++)
                    if (users[i].ID == user.ID)
                    {
                        users.RemoveAt(i);
                        SaveUsers(users);
                        return true;
                    }
            }
            catch (Exception ex)
            {
            }

            return false;
        }

        #endregion

        #region Helpers

        private void SaveUsers(List<User> users)
            => File.WriteAllLines(peopleDataPath,
                        users.Select(user => UserFileConverter.Instance.Convert(user)));

        private List<string> GetLines(string filePath) => File.ReadAllLines(filePath).ToList();

        #endregion
    }
}