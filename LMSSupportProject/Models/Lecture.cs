using System;

namespace LMSSupportProject.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    public class Lecture
    {
        public int id { get; set; }
        public string title { get; set; }
        public int? status { get; set; }
        public decimal? durationInMins { get; set; }
        public decimal? sizeInMB { get; set; }
        public decimal? MBsPerMinute { get; set; }
        public decimal? approximateInternetSpeedRequiredInMbps { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public DateTime createdAt { get; set; }
        public string createdBy { get; set; }
        public DateTime? updatedAt { get; set; }
        public string updatedBy { get; set; }
        public int isDeleted { get; set; }
        public string createdByEmail { get; set; }
        public string createdByName { get; set; }
        public string updatedByEmail { get; set; }
        public string updatedByName { get; set; }
        public Video video { get; set; }
        public Qualification qualification { get; set; }
        public Course course { get; set; }
        public Chapter chapter { get; set; }
        public Paper paper { get; set; }
    }


    public class Video
    {
        public string id { get; set; }
        public string status { get; set; }
        public DateTime? encodingStartedAt { get; set; }
        public DateTime? encodingEndedAt { get; set; }
    }

    public class Qualification
    {
        public int id { get; set; }
        public string title { get; set; }
        public int isDeleted { get; set; }
    }

    public class Course
    {
        public int id { get; set; }
        public string title { get; set; }
        public int isDeleted { get; set; }
    }

    public class Chapter
    {
        public int id { get; set; }
        public string title { get; set; }
        public int isDeleted { get; set; }
    }

    public class Paper
    {
        public int id { get; set; }
        public string title { get; set; }
        public int isDeleted { get; set; }
        public string trainer { get; set; }

    }
}
