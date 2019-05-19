using System;
using System.ComponentModel.DataAnnotations;

namespace personal_finances_two_api.Models
{
    public class AccessLog
    {
        public int Id { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }

        public DateTime Time { get; set; }

        public AccessLog (DateTime time, int userId)
        {
            Time = time;
            UserId = userId;
        }
    }
}