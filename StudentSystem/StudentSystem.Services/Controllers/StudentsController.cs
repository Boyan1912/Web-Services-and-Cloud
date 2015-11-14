namespace StudentSystem.Services.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;
    using StudentSystem.Data;
    using System.Net.Http;
    using System.Net;
    using StudentSystem.Services.Models;

    public class StudentsController : ApiController
    {
        private IStudentSystemData data;

        public StudentsController()
            : this(new StudentsSystemData())
        {
        }

        public StudentsController(IStudentSystemData studentData)
        {
            this.data = studentData;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return this.Ok(this.data.Students.All().Select(x => new StudentRequestModel
            {
                FirstName = x.FirstName,
                LastName = x.LastName
            }));
        }

        public IHttpActionResult Get(int id)
        {
            if (id < 0)
            {
                return this.BadRequest("Invalid Request");
            }

            return this.Ok(this.data.Students.SearchFor(x => x.StudentIdentification == id));    
        }

        [HttpGet]
        public IHttpActionResult GetByLevel(int level)
        {
            var result = this.data.Students.All().Select(x => x.Level == level);

            if (result.Count() < 1)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        [HttpPost]
        public IHttpActionResult GetHomeworks(int id)
        {
            var result = this.data.Students
                            .All()
                            .Where(st => st.StudentIdentification == id)
                            .Select(x => x.Homeworks
                                .OrderByDescending(h => h.CourseId)
                                .Select(hw => new HomeworkRequestModel
                                {
                                    Id = hw.Id,
                                    FileUrl = hw.FileUrl
                                }
                                )
                            );

            return this.Ok(result);
        }




    }
}