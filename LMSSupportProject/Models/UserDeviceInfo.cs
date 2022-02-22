using System;

namespace LMSSupportProject.Models
{
    public class UserDeviceInfo
    {
        public int? UserID { get; set; }
        public string DeviceID { get; set; }
        public string DeviceInfo { get; set; }
        public int? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
