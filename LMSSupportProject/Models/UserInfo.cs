using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LMSSupportProject.Models
{
    public class UserInfo
    {
        [Key]
        public int ID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<UserDeviceInfo> UserDevices { get; set; }
    }
}