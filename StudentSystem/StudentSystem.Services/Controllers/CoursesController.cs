namespace StudentSystem.Services.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web;
    using System.Web.Http;
    using StudentSystem.Data;
    using StudentSystem.Services.Models;
    public class CoursesController : ApiController
    {
        private IStudentSystemData data;

        public CoursesController()
            : this(new StudentsSystemData())
        {
        }

        public CoursesController(IStudentSystemData studentData)
        {
            this.data = studentData;
        }


        public IHttpActionResult Get()
        {
            return this.Ok(this.data.Courses.All().Select(c => new CourseRequestModel
                {
                    Name = c.Name,
                    Description = c.Description
                }));
        }

        public IHttpActionResult Get(string name)
        {
            var result = this.data.Courses.All()
                             .Where(c => c.Name == name)
                             .FirstOrDefault();

            if (result == null)
            {
                return this.NotFound();
            }
            else
            {
                return this.Ok(new CourseRequestModel
                {
                    Name = result.Name,
                    Description = result.Description
                });
            }
            
        }


    }
}