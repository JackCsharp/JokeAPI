using JokeAPI.Model;
using System;
using System.Security.Cryptography;

namespace JokeAPI.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        public UserService(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteUser(int id)
        {
            var response = await _context.Users.FindAsync(id);
            if(response == null) return false;
            _context.Users.Remove(response);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<User>> GetAllUsers()
        {
            List<User> users = new List<User> { };
            users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<List<User>?> GetUser(int id)
        {
            List<User> users = new List<User> { };
            var response = await _context.Users.FindAsync(id);
            if(response == null) return null;
            response.PasswordHash = null;
            response.PasswordSalt = null;
            users.Add(response);
            return users;
        }

        public async Task<User?> Login(UserDto request)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == request.Username);

            if (user == null)
            {
                return null;
            }


            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

            return user;
            
        }

        public async Task<User?> Register(UserDto request)
        {
            var existingUser = await _context.Users.SingleOrDefaultAsync(u => u.Username == request.Username);

            if (existingUser != null)
            {
                // Если пользователь с таким именем уже существует, вернуть false
                return null;
            }

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordsalt);

            User user = new User();
            user.Username = request.Username;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordsalt;
            user.GuildId = 1;


            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> UpdateUser(int id, UserDto request)
        {
            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null) 
            {
                return false;
            }
            existingUser.Username = request.Username;
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordsalt);
            existingUser.PasswordHash = passwordHash;
            existingUser.PasswordSalt = passwordsalt; 
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<Guild> UpdateUserGuild(int userid, int guildid)
        {
            var existingUser = await _context.Users.FindAsync(userid);
            if (existingUser == null)
            {
                return null;
            }
            existingUser.GuildId = guildid;

            var guild = await _context.Guilds.FindAsync(guildid);
            if (guild == null) return null;

            await _context.SaveChangesAsync();
            return guild;
        }
        public async Task<List<Joke>?> GetAllJokes(int userid)
        {
            var jokes = await _context.Jokes.Where(j => j.UserId == userid).ToListAsync();
            if (jokes == null) return null;
            return jokes;
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }
    }
}
