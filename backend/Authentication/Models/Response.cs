﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationLibrary.Models
{
    public class Response
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Token { get; set; }
    }
}
