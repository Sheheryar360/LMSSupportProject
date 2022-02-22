using System;
using System.Collections.Generic;

namespace LMSSupportProject.Models
{
    public class LectureDetails
    {
        public LectureModel LectureModels { get; set; }
        public string Video_ID { get; set; }
        public List<VideoModel> VideoModels { get; set; }
        public QualificationModel? QualificationModels { get; set; }
        public CourseModel CourceModels { get; set; }
        public ChapterModel ChapterModels { get; set; }
        public PaperModel PaperModels { get; set; }
        public string CreatedByEmail { get; set; }
        public string CreatedByName { get; set; }
        public string UpdatedByEmail { get; set; }
        public string UpdatedByName { get; set; }
        public string Trainer { get; set; }
        
    }

    public class LectureModel
    {
        public int? Lecture_ID { get; set; }
        public string Lecture_Title { get; set; }
        public int? Lecture_Status { get; set; }
        public Decimal? DurationInMins { get; set; }
        public Decimal? SizeInMB { get; set; }
        public Decimal? MBsPerMinute { get; set; }
        public Decimal? ApproximateInternetSpeedRequiredInMbps { get; set; }
        public DateTime? Lecture_StartDate { get; set; }
        public DateTime? Lecture_EndDate { get; set; }
        public DateTime? Lecture_CreatedAt { get; set; }
        public string Lecture_CreatedBy { get; set; }
        public DateTime? Lecture_UpdatedAt { get; set; }
        public string Lecture_UpdatedBy { get; set; }
        public int? Lecture_Deleted { get; set; }
    }

    public class QualificationModel
    {
        public int? Qualification_ID { get; set; }
        public string QualificationTitle { get; set; }
        public int? Qualification_Deleted { get; set; }
    }
    public class CourseModel
    {
        public int Cource_ID { get; set; }
        public string Cource_Title { get; set; }
        public int? Cource_Deleted { get; set; }

    }
    public class ChapterModel
    {
        public int Chapter_ID { get; set; }
        public string Chapter_Title { get; set; }
        public int? Chapter_Deleted { get; set; }
    }
    public class PaperModel
    {
        public int Paper_ID { get; set; }
        public string Paper_Title { get; set; }
        public int? Paper_Deleted { get; set; }
    }

    public class ResponseLecture
    {
        public List<LectureDetails> LectureDetails { get; set; }
        public List<HandoutDetails> HandoutDetails { get; set; }
    }
}
