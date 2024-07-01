using WebAPIBatch20.Entities;
using WebAPIBatch20.Models;
using WebAPIBatch20.Repositories.Interfaces;
using WebAPIBatch20.Services.Interfaces;
using static WebAPIBatch20.Models.CourseModels;

namespace WebAPIBatch20.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public BaseResponse Add(CourseRequest request)
        {
            var courseExists = _courseRepository.Exists(request.Name);
            if (courseExists)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = $"Course with name {request.Name} exists"
                };
            }

            var course = new Course
            {
                Name = request.Name,
                Description = request.Description,
                IsActive = true
            };
            _courseRepository.AddCourse(course);

            return new BaseResponse
            {
                Status = true,
                Message = "Course added successfully"
            };

        }

        public BaseResponse DeActivate()
        {
            throw new NotImplementedException();
        }

        public BaseResponse Edit(int id, CourseRequest request)
        {
            var existingCourse = _courseRepository.GetById(id);
            if (existingCourse == null)
            {
                return new BaseResponse
                {
                    Message = $"Course with Id {id} Not found"
                };
            }

            existingCourse.Name = request.Name ?? existingCourse.Name;
            existingCourse.Description = request.Description ?? existingCourse.Description;

            _courseRepository.UpdateCourse(existingCourse);
            return new BaseResponse
            {
                Status = true,
                Message = "Course updated successfully"
            };
        }

        public CourseResponse Get(int id)
        {
            var course = _courseRepository.GetById(id);
            if (course == null)
            {
                return new CourseResponse
                {
                    Message = $"Course with Id {id} Not found"
                };
            }

            return new CourseResponse
            {
                Data = new CourseModel
                {
                    Id = course.Id,
                    Name = course.Name,
                    Description = course.Description,
                    IsActive = course.IsActive
                },
                Status = true,
                Message = "Course retrieved successfully"
            };

        }

        public CoursesResponse GetAllCourses()
        {
            var courses = _courseRepository.GetAll();

            return new CoursesResponse
            {
                Data = courses.Select(c => new CourseModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    IsActive = c.IsActive
                }).ToList(),
                Status = true,
                Message = "Courses retrived successfully"
            };

        }
    }
}
