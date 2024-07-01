using WebAPIBatch20.Entities;

namespace WebAPIBatch20.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        public Course AddCourse(Course course);
        public Course UpdateCourse(Course course);
        public IEnumerable<Course> GetAll();
        public Course GetById(int id);
        public bool Exists(string name);
    }
}
