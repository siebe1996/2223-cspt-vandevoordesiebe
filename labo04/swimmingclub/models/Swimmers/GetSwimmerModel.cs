﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models.Swimmers
{
    public class GetSwimmerModel : BaseSwimmerModel
    {
        [Required]
        public Guid Id { get; set; }
    }
}
