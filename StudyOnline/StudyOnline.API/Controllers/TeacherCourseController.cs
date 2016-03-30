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
    public class TeacherCourseController : ApiController
    {
        // GET api/teachercourses/
        TeacherService teacherService = new TeacherService();

       [HttpGet, ActionName("getcourseviewcount")]
        public IEnumerable<Tuple<User, Course>> Get()
        {
            return teacherService.GetListByTearcherId(1).OrderByDescending(x=>x.Item2.ViewCount).Skip(1).Take(4);
        }


      [HttpGet, ActionName("getcoursecreatedate")]
        public IEnumerable<Tuple<User, Course>> GetListByTearcherCreateDate()
        {
                return teacherService.GetListByTearcherId(1).OrderByDescending(x => x.Item2.CreateDate).Skip(1).Take(4);
           
        }

      [HttpGet, ActionName("getcourseprice")]
      public IEnumerable<Tuple<User, Course>> GetListByTearcherPrice()
      {
          return teacherService.GetListByTearcherId(1).OrderByDescending(x => x.Item2.CreateDate).Where(x=>x.Item2.Price==0);

      }

        // POST api/teachercourse
        public void Post([FromBody]string value)
        {
        }

        // PUT api/teachercourse/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/teachercourse/5
        public void Delete(int id)
        {
        }
    }
}
