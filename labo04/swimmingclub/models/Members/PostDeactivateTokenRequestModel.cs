using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models.Members
{
    public class PostDeactivateTokenRequestModel
    {
        //[Required]
        public string Token { get; set; }
    }
}
