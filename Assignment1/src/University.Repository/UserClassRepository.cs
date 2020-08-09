using System.Collections.Generic;
using System.Linq;

namespace University.Repository
{
    public interface IUserClassRepository
    {
        ClassModel[] GetUserClasses(int UserId);
        void EnrollUserInClass(int UserId, int ClassId);
        void RemoveUserFromClass(int UserId, int ClassId);
    }

    public class UserClassModel
    {
        public int ClassId { get; set; }
        public int UserId { get; set; }

    }

    public class UserClassRepository : IUserClassRepository
    {
        public ClassModel[] GetUserClasses(int UserId) 
        {
            var user = DatabaseAccessor.Instance.Users.FirstOrDefault(t => t.UserId == UserId);

            return user.Classes.Select(t => new ClassModel 
                                                { Id = t.ClassId, 
                                                  Name = t.ClassName, 
                                                  Description = t.ClassDescription, 
                                                  Price = t.ClassPrice })
                               .ToArray();
        }

        public void EnrollUserInClass(int UserId, int ClassId)
        {
            var user = DatabaseAccessor.Instance.Users.FirstOrDefault(t => t.UserId == UserId);
            var newClass = DatabaseAccessor.Instance.Classes.FirstOrDefault(t => t.ClassId == ClassId);

            user.Classes.Add(newClass);
            DatabaseAccessor.Instance.SaveChanges();
        }

        public void RemoveUserFromClass(int UserId, int ClassId)
        {
            var user = DatabaseAccessor.Instance.Users.FirstOrDefault(t => t.UserId == UserId);
            var classToRemove = DatabaseAccessor.Instance.Classes.FirstOrDefault(t => t.ClassId == ClassId);

            user.Classes.Remove(classToRemove);
            DatabaseAccessor.Instance.SaveChanges();
        }
    }
}
