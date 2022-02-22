using System;
using System.ComponentModel.DataAnnotations;

namespace LMSSupportProject.Models
{
    public class EncodingJobDetail
    {
        [Key]
        public int? ID { get; set; }
        public string JobID { get; set; }
        public string Status { get; set; }
        public Double? Details { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
