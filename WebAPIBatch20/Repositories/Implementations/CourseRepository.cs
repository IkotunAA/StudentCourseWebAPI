using WebAPIBatch20.Context;
using WebAPIBatch20.Entities;
using WebAPIBatch20.Repositories.Interfaces;

namespace WebAPIBatch20.Repositories.Implementations
{
    public class CourseRepository : ICourseRepository
    {
        private readonly WebAPIDbContext _context;
        public CourseRepository(WebAPIDbContext context)
        {
            _context = context;
        }

        public Course AddCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
            return course;
        }

        public IEnumerable<Course> GetAll()
        {
            return _context.Courses.ToList();
        }

        public Course GetById(int id)
        {
            return _context.Courses.Find(id);
        }

        public bool Exists(string name)
        {
            return _context.Courses.Any(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public Course UpdateCourse(Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();
            return course;
        }
    }
}
