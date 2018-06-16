namespace RWAProject.DAL {
    public class DatabaseFacade {
        public static IRepository Repository { get; } = new DatabaseRepository();
    }
}
