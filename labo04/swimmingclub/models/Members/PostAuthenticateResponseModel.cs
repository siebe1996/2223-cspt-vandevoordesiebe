using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace models.Members
{
    public class PostAuthenticateResponseModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string UserName { get; set; }

        [Required]
        public string JwtToken { get; set; }

        public ICollection<string> Roles { get; set; }

        [JsonIgnore]
        public string RefreshToken { get; set; }
    }
}
