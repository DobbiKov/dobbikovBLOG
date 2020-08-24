using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myblog.Data;
using myblog.Models;
using myblog.TelegramBot.Functions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace myblog.Interfaces
{
    public class EFPostRepository : IPostRepository
    {
        private ApplicationDbContext db;
        IWebHostEnvironment _appEnvironment;
        public EFPostRepository(ApplicationDbContext _db, IWebHostEnvironment appEnvironment)
        {
            db = _db;
            _appEnvironment = appEnvironment;
        }
        public async Task<ActionResult<Post>> Create(Post post)
        {
           /* public IFormFile photo { get; set; }*/
/*            if(post.photo != null)
            {
                string path = $"\\Files\\Photos\\DobbiPosts\\{post.photo.FileName}";
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await post.photo.CopyToAsync(fileStream);
                }
                post.Image = path;
                await db.files.AddAsync(new FileModel() { Name = post.photo.FileName, Path = path });
                await db.SaveChangesAsync();
                await BotSendMessage.ToShBPhoto(post.photo);
            }*/
/*            await BotSendMessage.ToDobbiKovBlog(post.Text);
            await BotSendMessage.ToShB(post.Text);*/
            await db.posts.AddAsync(post);
            await db.SaveChangesAsync();
            return post;
        }

        public async Task UploadPhoto(Guid id, IFormFile file)
        {
            var post = await db.posts.FirstOrDefaultAsync(x => x.Id == id);
            if(post != null)
            {
                if(file != null)
                {
                    string path = $"\\Files\\Photos\\DobbiPosts\\{file.FileName}";
                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    post.Image = path;
                    await db.files.AddAsync(new FileModel() { Name = file.FileName, Path = path });
                    await db.SaveChangesAsync();
                    await BotSendMessage.ToShBPhoto(post.photo);
                }
            }
        }

        public async Task Delete(Guid id)
        {
            db.posts.Remove(await db.posts.FirstOrDefaultAsync(x => x.Id == id));
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Post>> GetAsync()
        {
            await Init();
            return await db.posts.ToArrayAsync();
        }

        public async Task<ActionResult<Post>> GetAsync(Guid id)
        {
            var post = await db.posts.FirstOrDefaultAsync(x => x.Id == id);
            return post;
        }

        public async Task Init()
        {
            if (!db.posts.Any())
            {
                await db.posts.AddRangeAsync
                (
                    new Post() { Id = new Guid("00000000-0000-0000-0000-000000000001"), Link = "https://github.com/DobbiKov", Title = "DobbiKov acc", Name = "DobbiKov", Text = "a", Image = "huy" },
                    new Post() { Id = new Guid("00000000-0000-0000-0000-000000000002"), Link = "https://github.com/DobbiKov/dobbikovBLOG", Title = "my DobbiKov Blog", Name = "DobbiKov Blog", Text = "a", Image = "huy" },
                    new Post() { Id = new Guid("00000000-0000-0000-0000-000000000003"), Link = "https://github.com/DobbiKov/dobbikovBLOG", Title = "my DobbiKov Blog", Name = "DobbiKov Blog", Text = "a", Image = "huy" }
                );
                await db.SaveChangesAsync();
            }
        }

        public async Task<ActionResult<Post>> Update(Post post)
        {
            db.Entry(post).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return await GetAsync(post.Id);
        }
    }
}
