namespace RWAProject.DAL
{
    public static class RepositoryFacade
    {
        private static bool dbRepo;

        private static IRepository dbRepository = new DatabaseRepository();
        private static IRepository fileRepository = new FileRepository();

        public static bool DatabaseRepository
        {
            get => dbRepo;
            set
            {
                if (dbRepo != value)
                {
                    dbRepo = value;
                    RepositoryChanged?.Invoke(null, System.EventArgs.Empty);
                }
            }
        }

        public static IRepository Repository => DatabaseRepository
            ? dbRepository
            : fileRepository;

        public static event System.EventHandler RepositoryChanged;
    }
}
