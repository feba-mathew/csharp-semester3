using University.Repository;

namespace University.Business
{
    public interface IUserClassManager
    {
        void EnrollInClass(UserClassModel userClassModel);
        void RemoveUserFromClass(UserClassModel userClassModel);
        ClassModel[] GetUserClasses(int UserId);
    }

    public class UserClassModel
    {
        public int UserId { get; set; }
        public int ClassId { get; set; }
    }

    public class UserClassManager : IUserClassManager
    {
        private readonly IUserClassRepository userClassRepository;

        public UserClassManager(IUserClassRepository userClassRepository)
        {
            this.userClassRepository = userClassRepository;
        }

        public void EnrollInClass(UserClassModel userClassModel)
        {
            userClassRepository.EnrollUserInClass(userClassModel.UserId, userClassModel.ClassId);
        }

        public void RemoveUserFromClass(UserClassModel userClassModel)
        {
            userClassRepository.RemoveUserFromClass(userClassModel.UserId, userClassModel.ClassId);
        }

        public ClassModel[] GetUserClasses(int UserId)
        {
            var userClasses = userClassRepository.GetUserClasses(UserId);

            ClassModel[] classModels = new ClassModel[userClasses.Length];
            for (int i= 0; i < classModels.Length; i++)
            {
                classModels[i] = new ClassModel(userClasses[i].Id, userClasses[i].Name, userClasses[i].Description, userClasses[i].Price);
            }

            return classModels;
        }
    }
}
