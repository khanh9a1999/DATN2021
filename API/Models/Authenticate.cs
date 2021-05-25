﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Authenticate
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}