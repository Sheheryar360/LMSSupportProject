using System;

namespace LMSSupportProject.Models
{
    public class VideoModel
    {
        public int Video_ID { get; set; }
        public string Video_FileName { get; set; }
        public string Video_FilePath { get; set; }
        public string Video_Status { get; set; }
        public string Video_AccountID { get; set; }
        public Decimal? Video_Duration { get; set; }
        public Decimal? Video_FileSize { get; set; }
        public string Video_MediaFilesPath { get; set; }
        public string Video_SourceFileURL { get; set; }
        public string Video_StatusNotificationURL { get; set; }
        public DateTime? Video_CreatedAt { get; set; }
        public DateTime? Video_EncodingStartedAt { get; set; }
        public DateTime? Video_EncodingEndedAt { get; set; }
    }
}
