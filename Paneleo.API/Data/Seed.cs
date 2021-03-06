using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Paneleo.API.Models;
using Paneleo.API.Repository.DatabaseContext;

namespace Paneleo.API.Data
{
    public class Seed
    {
        private readonly ApplicationDbContext _context;
        public Seed(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void SeedUsers()
        {
            if (!_context.Users.Any())
            {
                var userData = System.IO.File.ReadAllText("Data/UserSeedData.json");
                var users = JsonConvert.DeserializeObject<List<User>>(userData);
                foreach (var user in users)
                {
                    byte[] passwordHash, passwordSalt;
                    CreatePasswordHash("Bartek123", out passwordHash, out passwordSalt);

                    user.PaswordHash = passwordHash;
                    user.PaswordSalt = passwordSalt;
                    user.Username = user.Username.ToLower();

                    user.LastActive = DateTime.Now;

                    _context.Users.Add(user);
                }
                _context.SaveChanges();
            }

        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}