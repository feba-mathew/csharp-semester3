
using University.ClassDatabase;

namespace University.Repository
{
    public class DatabaseAccessor
    {
        private static readonly UniversityEntities entities;

        static DatabaseAccessor()
        {
            entities = new UniversityEntities();
            entities.Database.Connection.Open();
        }

        public static UniversityEntities Instance
        {
            get
            {
                return entities;
            }
        }
    }
}