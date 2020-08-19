using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public Task Create(DobbiUser post)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<DobbiUser>> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DobbiUser>> GetAsync()
        {

            var res = await db.users.ToArrayAsync();
            return res;
        }

        public async Task<ActionResult<DobbiUser>> GetAsync(Guid id)
        {
            var user = await db.users.FirstOrDefaultAsync(x => x.Id == id);
            return user;
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
                    new DobbiUser() { Id = new Guid("00000000-0000-0000-0000-000000000001"), Login = "dobbikov@gmail.com", Password = "123456", TestRole = role}
                );
                db.SaveChanges();
            }
        }

        public Task Update(DobbiUser post)
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
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                token = encodedJwt,
                userId = identity.Id,
                roleId = identity.UserRoleId,
                name = identity.Login
            };

            return new OkObjectResult(response);
            /*throw new NotImplementedException();*/
        }
        public DobbiUser GetIdentity(string username, string password)
        {
            var person = db.users.FirstOrDefault(x => x.Login == username && x.Password == password);
            if(person != null)
            {
                return person;
                /*var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.TestRole)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;*/
            }

            return null;
        }
    }
}
