using System.Collections.Generic;
using System.Web.UI;

using RWAProject.DAL;

namespace RWAProject.WebFormsClient
{
    public static class Utils
    {
        public static List<T> GetSpecificControls<T>(Control root) where T : Control
        {
            var controls = new List<T>();
            ControlFinder(root);

            void ControlFinder(Control current)
            {
                foreach (Control control in current.Controls)
                {
                    if (control is T foundControl)
                        controls.Add(foundControl);

                    ControlFinder(control);
                }
            }

            return controls;
        }

        public static List<Control> GetControls<T>(Control root)
        {
            var controls = new List<Control>();
            ControlFinder(root);

            void ControlFinder(Control current)
            {
                foreach (Control control in current.Controls)
                {
                    if (control is T || control.GetType().IsAssignableFrom(typeof(T)))
                        controls.Add(control);

                    ControlFinder(control);
                }
            }

            return controls;
        }

        public static List<Role> GetRoles() => new List<Role>(RepositoryFacade.Repository.GetRoles());

        public static List<City> GetCities() => new List<City>(RepositoryFacade.Repository.GetCities());

        public static List<User> GetUsers() => new List<User>(RepositoryFacade.Repository.GetUsers());
    }
}