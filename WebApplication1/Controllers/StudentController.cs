using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DATA;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    
    
    public class StudentController : Controller
    {
        public readonly ApplicationDbContext _db;
        public StudentController(ApplicationDbContext db)
        {
            _db = db;   
        }
        public IActionResult Index()
        {
            var students = _db.Students.Include(s => s.Address).ToList();
            return View(students);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add([FromBody]Student student)
        {            
                if (ModelState.IsValid)
                {
                    // Ensure Addresses is not null
                    if (student.Address == null)
                    {
                        student.Address = new List<Address>();
                    }

                    _db.Students.Add(student);
                    _db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
        public IActionResult Edit(int id )
        {
            var students = _db.Students.FirstOrDefault(x => x.Id == id);    
            if(students == null)    
                return NotFound();
            else
            return View(students);
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {


                var students = _db.Students.FirstOrDefault(u => u.Id == student.Id);
                if (students == null)
                {
                    return NotFound();
                }
                else
                {
                    students.Name = student.Name;
                    students.Course = student.Course;
                    students.Gender = student.Gender;
                    _db.Update(students);
                    _db.SaveChanges();
                  

                }
            }
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var students = _db.Students.FirstOrDefault(u => u.Id ==id);
            return View(students);  

        }
        [HttpPost]
        public IActionResult Delete(Student student)
        {
           if(student == null) return NotFound();   
           else _db.Students.Remove(student);
            _db.SaveChanges();
        return RedirectToAction("Index");
        }
        
    }
}
