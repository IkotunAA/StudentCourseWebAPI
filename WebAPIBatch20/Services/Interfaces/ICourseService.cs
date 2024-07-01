using WebAPIBatch20.Models;
using static WebAPIBatch20.Models.CourseModels;

namespace WebAPIBatch20.Services.Interfaces
{
    public interface ICourseService
    {
        public BaseResponse Add(CourseRequest request);
        public BaseResponse Edit(int id, CourseRequest request);
        public BaseResponse DeActivate();
        public CourseResponse Get(int id);
        public CoursesResponse GetAllCourses();
    }
}
