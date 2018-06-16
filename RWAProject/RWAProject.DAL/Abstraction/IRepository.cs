using System.Collections.Generic;

namespace RWAProject.DAL {
    public interface IRepository {
        #region Create

        bool AddUser(User user);
        bool AddEmail(User user, string email);

        #endregion

        #region Retreive

        IEnumerable<User> GetUsersByEmail(string email);
        IEnumerable<User> GetUsers();
        IEnumerable<City> GetCities();
        IEnumerable<Role> GetRoles();
        User Login(string username, string password);

        #endregion

        #region Update

        bool UpdateUser(User user);

        #endregion

        #region Delete

        bool RemoveUser(User user);

        #endregion
    }
}
