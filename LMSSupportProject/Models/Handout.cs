using System;

namespace LMSSupportProject.Models
{
    public class Handout
    {
        public int id { get; set; }
        public string title { get; set; }
        public string path { get; set; }
        public int? sequence { get; set; }
        public string fileType { get; set; }
        public int? status { get; set; }
        public DateTime createdAt { get; set; }
        public string createdBy { get; set; }
        public DateTime? updatedAt { get; set; }
        public string updatedBy { get; set; }
        public int? isDeleted { get; set; }
        
        public Qualification qualification { get; set; }
        public Course course { get; set; }
        public Chapter chapter { get; set; }
        public Paper paper { get; set; }
    }
}
