using System;

namespace LMSSupportProject.Models
{
    public class HandoutDetails
    {
        public int? FileID { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int? FileSequence { get; set; }
        public string FileType { get; set; }
        public int? FileStatus { get; set; }
        public DateTime? FileCreatedAt { get; set; }
        public CreatedBy FileCreatedBy { get; set; }
        public int? FileUpdatedBy { get; set; }
        public DateTime? FileUpdatedAt { get; set; }
        public int? ChapterID { get; set; }
        public string ChapterTitle { get; set; }
        public int? PaperID { get; set; }
        public string PaperTitle { get; set; }
        public string Trainer { get; set; }
        public int? CourseID { get; set; }
        public string CourseTitle { get; set; }
        public int? QualificationID { get; set; }
        public string QualificationTitle { get; set; }
        public int? FileDeleted { get; set; }
        public int? ChapterDeleted { get; set; }
        public int? PaperDeleted { get; set; }
        public int? CourseDeleted { get; set; }
        public int? QualificationDeleted { get; set; }
    }
    public class CreatedBy
    {
        public int? Id { get; set; }
        public string FullName { get; set; }
    }
    /*public class UpdatedBy
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }*/
}
