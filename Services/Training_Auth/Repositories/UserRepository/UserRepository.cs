using IrisTraining_Auth.Context;
using IrisTraining_Auth.Models;

namespace IrisTraining_Auth.Repositories.UserRepository
{
    public class UserRepository : Repositories<User> , IUserRepository
    {
        public UserRepository(DatabaseContext context):base(context) { }
    }
}
