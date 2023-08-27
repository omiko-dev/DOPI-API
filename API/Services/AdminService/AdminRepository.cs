using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Services.AdminService
{
    public class AdminRepository : IAdminRepository
    {
        private readonly UserDbContext userDb;

        public AdminRepository(UserDbContext userDb)
        {
            this.userDb = userDb;
        }

        public async Task<List<User>> GetAllUser()
        {
            return await this.userDb.Users.ToListAsync<User>();   
        }

        public async Task<User> RemoveUser(int id)
        {
            var users = await this.userDb.Users.FirstOrDefaultAsync(x => x.Id == id);


            if (users == null)
                return null;

            users.Id = 0;

            userDb.Users.Remove(users);
            await userDb.SaveChangesAsync();

            return users;

        }
    }
}
