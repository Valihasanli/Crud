using Mamba.DAL;
using Mamba.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Mamba.Areas.Admin.Controllers
{
    [Area ("Admin")]
    public class MemberController : Controller
    {
        AppDbContext _dbContext;

        public MemberController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<Member> members = _dbContext.Members.ToList();
            return View(members);
        }
        public IActionResult Delete(int id)
        {
            var member = _dbContext.Members.FirstOrDefault(x => x.Id == id);
            if (member == null)
            {
                return RedirectToAction("Index");
            }
            _dbContext.Members.Remove(member);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Member member) 
        {
            string path = @"C:\\Users\\User\\Desktop\\mambaa\\Mamba\\Mamba\\wwwroot\\Uploads\\";
            using(FileStream stream=new FileStream(path+member.ImgFile.FileName, FileMode.Create))
            {
                member.ImgFile.CopyTo(stream);
            }
            member.ImgUrl = member.ImgFile.FileName;
            if (!ModelState.IsValid)
            {
                return View();
            }
            _dbContext.Members.Add(member);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int id)
        {
            var item= _dbContext.Members.FirstOrDefault(x=>x.Id == id);
            return View(item);
        }
        [HttpPost]
        public IActionResult Update(Member newmember)
        {
            string path = @"C:\\Users\\User\\Desktop\\mambaa\\Mamba\\Mamba\\wwwroot\\Uploads\\";
            using(FileStream stream=new FileStream(path + newmember.ImgFile.FileName, FileMode.Create))
            {
                newmember.ImgFile.CopyTo(stream);
            }
           
            var oldmember= _dbContext.Members.FirstOrDefault(x=>x.Id==newmember.Id);
            oldmember.ImgUrl = newmember.ImgFile.FileName;
            oldmember.Proffesion= newmember.Proffesion; 
            oldmember.Fulllname=newmember.Fulllname;
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        
    }
}
