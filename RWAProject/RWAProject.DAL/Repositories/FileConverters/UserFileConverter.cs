using System;
using System.Linq;

namespace RWAProject.DAL
{
    class UserFileConverter : BaseFileConverter<UserFileConverter, User>
    {
        private const string emailSeparator = "_\\|/_";

        public UserFileConverter()
        {
            Separator = "\\*/";
        }

        public override string Convert(User obj)
            => string.Join(Separator,
                obj.ID,
                obj.Name,
                obj.Surname,
                obj.Password,
                obj.Telephone,
                obj.RoleID,
                obj.CityID,
                string.Join(emailSeparator,
                    obj.Emails.Select(email => EmailFileConverter.Instance.Convert(email)))
               );

        public override User ConvertBack(string line)
        {
            var data = line?.Split(new string[] { Separator }, StringSplitOptions.None);

            if (data == null || data.Length != 8 || !(
                int.TryParse(data[0], out int id) &&
                int.TryParse(data[5], out int roleID) &&
                int.TryParse(data[6], out int cityID)
            ))
                return null;

            var emails = new System.Collections.Generic.HashSet<PersonEmail>(data[7]
                .Split(new string[] { emailSeparator }, StringSplitOptions.None)
                .Select(emailString => EmailFileConverter.Instance.ConvertBack(emailString))
                .Where(email => email != null)
            );

            return new User
            {
                ID = id,
                Name = data[1],
                Surname = data[2],
                Password = data[3],
                Telephone = data[4],
                RoleID = roleID,
                CityID = cityID,
                Emails = emails
            };
        }
    }
}