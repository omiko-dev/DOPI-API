namespace API.Services.AdminService
{
    public interface IAdminRepository
    {

        public Task<List<User>> GetAllUser();

        public Task<User> RemoveUser(int id);

    }
}
