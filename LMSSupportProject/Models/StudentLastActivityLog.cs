using System;
using System.Collections.Generic;

namespace LMSSupportProject.Models
{
    public class StudentLastActivityLog
    {
        public int? LectureViewID { get; set; }
        public int? LectureID { get; set; }
        public string LectureTitle { get; set; }
        public string VideoID { get; set; }
        public DateTime? LogAt { get; set; }
        public string Course { get; set; }
        public string Chapter { get; set; }
        public string Lecture { get; set; }
        public Decimal? DurationInMins { get; set; }
        public Decimal? SizeInMB { get; set; }
        public Decimal? ApproximateInternetSpeedRequiredInMbps { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? LectureCreatedAt { get; set; }
    }

    class Response
    {
        public List<StudentLastActivityLog> LectureViews { get; set; }
        public List<UserInfo> UserInfo { get; set; }
    }
}
