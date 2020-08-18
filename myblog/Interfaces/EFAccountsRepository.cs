using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using myblog.Data;
using myblog.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace myblog.Interfaces
{
    public class EFAccountsRepository : IAccountsRepository
    {
        private readonly ApplicationDbContext db;
        public EFAccountsRepository(ApplicationDbContext _db)
        {
            db = _db;
        }
        public Task Create(ApplicationUser post)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<ApplicationUser>> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ApplicationUser>> GetAsync()
        {

            throw new NotImplementedException();
        }

        public Task<ActionResult<ApplicationUser>> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task Init()
        {
            if (!db.users.Any())
            {
                await db.users.AddAsync(
                    new DobbiUser() { Id = new Guid("00000000-0000-0000-0000-000000000001"), Login = "dobbikov@gmail.com", Password = "123456", TestRole = "SysAdmin" }
                );
                await db.SaveChangesAsync();
            }
        }

        public void Init(string role)
        {
            if (!db.users.Any())
            {
                db.users.Add(
                    new DobbiUser() { Id = new Guid("00000000-0000-0000-0000-000000000001"), Login = "dobbikov@gmail.com", Password = "123456", TestRole = role }
                );
                db.SaveChanges();
            }
        }

        public Task Update(ApplicationUser post)
        {
            throw new NotImplementedException();
        }
        
        public IActionResult GetToken(string username, string password)
        {
            Init("SysAdmin");
            var identity = GetIdentity(username, password);
            if (identity == null)
            {
                return null;
            }
            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            return new OkObjectResult(response);
            /*throw new NotImplementedException();*/
        }
        public ClaimsIdentity GetIdentity(string username, string password)
        {
            var person = db.users.FirstOrDefault(x => x.Login == username && x.Password == password);
            if(person != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.TestRole)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            return null;
        }
    }
}
