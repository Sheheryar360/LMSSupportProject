using LMSSupportProject.Attributes;
using LMSSupportProject.DataManager;
using LMSSupportProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LMSSupportProject.Controllers
{
    [APIAuthFilter]
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Route("api/lecture")]
        [HttpGet]
        public IActionResult LectureDetails([FromQuery] string InstituteID, [FromQuery] int? LectureID = null, [FromQuery] string LectureTitle = null, [FromQuery] int? ChapterID = null, [FromQuery] int? PaperID = null, [FromQuery] string Name = null)
        {
            if (string.IsNullOrEmpty(InstituteID) ||
                (LectureID == null &&
                string.IsNullOrEmpty(LectureTitle) &&
                ChapterID == null &&
                PaperID == null &&
                string.IsNullOrEmpty(Name)))
                return BadRequest();

            var model = new StudentLastActivityData(_configuration);

            List<Lecture> lectureDetails = model.GetLectureDetails(InstituteID, LectureID, LectureTitle, ChapterID, PaperID);

            //List<HandoutDetails> handoutDetails = model.GetHandoutDetails(InstituteID, ChapterID, PaperID, Name);

            /*var response = new ResponseLecture();
            response.LectureDetails = lectureDetails;
            response.HandoutDetails = handoutDetails;*/

            return Ok(lectureDetails);
        }

        [Route("api/handout")]
        [HttpGet]
        public IActionResult HandoutDetails([FromQuery] string InstituteID, [FromQuery] int? ChapterID = null, [FromQuery] int? PaperID = null, [FromQuery] string Title = null)
        {


            if (string.IsNullOrEmpty(InstituteID) || (ChapterID == null && PaperID == null && Title == null))
                return BadRequest();

            var model = new StudentLastActivityData(_configuration);

            try
            {
                List<Handout> handoutDetails = model.GetHandoutDetails(InstituteID, ChapterID, PaperID, Title);


                return Ok(handoutDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [Route("api/UserActivityInformation")]
        [HttpGet]
        public IActionResult UserActivityInformation([FromQuery] string InstituteID, [FromQuery] string UserEmail = null, [FromQuery] int? UserID = null)
        {

            if (string.IsNullOrEmpty(InstituteID) ||
            (string.IsNullOrEmpty(UserEmail) && UserID == null))
                return BadRequest();


            var model = new StudentLastActivityData(_configuration);
            try
            {
                int noofdays = _configuration.GetValue<int>("GetNoOfDays:NoOfDays");
                List<StudentLastActivityLog> data = model.GetStudentLastActivityData(InstituteID, UserEmail, noofdays, UserID);

                List<UserInfo> userInfo = model.GetUserInfo(InstituteID, UserEmail);

                List<UserDeviceInfo> userDeviceInfo;

                for (int i = 0; i < userInfo.Count; i++)
                {
                    userDeviceInfo = model.GetUserDeviceInfo(userInfo[i].ID);
                    userInfo[i].UserDevices = userDeviceInfo;
                }

                var response = new Response();
                response.LectureViews = data;
                response.UserInfo = userInfo;

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

            return BadRequest();
        }
    }
}
