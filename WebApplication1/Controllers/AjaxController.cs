using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using WebApplication1.DATA;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    public class AjaxController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AjaxController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Student> students =new  List<Student>();
            students= _db.Students.ToList();  
            return Json(students);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add([FromBody] Student student)
        {
            if (ModelState.IsValid)
            {
                _db.Students.Add(student);
                _db.SaveChanges();
            }
            return Ok();
        }

        [HttpGet]
        public IActionResult GetbyId(int id)
        {
            var students = _db.Students.FirstOrDefault(u=> u.Id == id);
            if (students == null)
            {
                return BadRequest();
            }
            else
            return Json(students);
        }
        [HttpPost]
        public IActionResult Edit([FromBody] Student student)
        {
            if (ModelState.IsValid)
            {
                var students = _db.Students.FirstOrDefault(u => u.Id == student.Id);
                if (students == null)
                {
                    return BadRequest();
                }
                else
                {
                    students.Name = student.Name;
                    students.Course = student.Course;
                    students.Gender = student.Gender;
                    _db.Students.Update(students);
                    _db.SaveChanges();
                }
            }
            return View("Index");
        }
       
        [HttpPost]
        public IActionResult DeleteById(int id)
        {
            var stu = _db.Students.FirstOrDefault(s => s.Id == id);
            if (stu == null)
            {
                return BadRequest();
            }
            else
            {
                _db.Students.Remove(stu);
                _db.SaveChanges();
                return View("Index");
            }
        }
    }
}
