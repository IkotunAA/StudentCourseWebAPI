namespace WebAPIBatch20.Models
{
    public class CourseModels
    {
        public class CourseRequest
        {
            public string Name { get; set; }    
            public string Description { get; set; }    
        }

        public class CourseModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public bool IsActive { get; set; }
        }

        public class CourseResponse : BaseResponse
        {
            public CourseModel Data { get; set; }
        }

        public class CoursesResponse : BaseResponse
        {
            public IEnumerable<CourseModel> Data { get; set; }
        }
    }
}
