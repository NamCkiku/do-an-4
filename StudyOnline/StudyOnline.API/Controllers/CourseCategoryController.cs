using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudyOnline.Entities.Models;
using StudyOnline.Service;

namespace StudyOnline.API.Controllers
{
    public class CourseCategoryController : ApiController
    {
        // GET api/coursecategory
        CourseCategoryService cal = new CourseCategoryService();
        public IEnumerable<CourseCategory> Get()
        {
            return cal.ListAllCourseCategory();
        }

        // GET api/coursecategory/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/coursecategory
        public void Post([FromBody]string value)
        {
        }

        // PUT api/coursecategory/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/coursecategory/5
        public void Delete(int id)
        {
        }
    }
}
