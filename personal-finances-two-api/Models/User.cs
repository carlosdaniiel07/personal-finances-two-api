using System.Collections.Generic;

using Newtonsoft.Json;

namespace personal_finances_two_api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nickname  { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public bool Enabled { get; set; }

        [JsonIgnore]
        public ICollection<AccessLog> AccessLogs { get; set; }
    }
}