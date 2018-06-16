namespace RWAProject.DAL
{
    class EmailFileConverter : BaseFileConverter<EmailFileConverter, PersonEmail>
    {
        public EmailFileConverter()
        {
            Separator = "~#~";
        }

        public override string Convert(PersonEmail obj) 
            => string.Join(Separator, obj.PersonID, obj.Email);

        public override PersonEmail ConvertBack(string line)
        {
            var data = line?.Split(new string[] { Separator }, System.StringSplitOptions.None);

            if (data == null || data.Length != 2 || !int.TryParse(data[0], out int userID))
                return null;

            return new PersonEmail
            {
                Email = data[1],
                PersonID = userID
            };
        }
    }
}
