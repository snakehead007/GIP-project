﻿using Gip.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gip.Models
{
    public class EditUserViewModel
    {
        public EditUserViewModel() 
        {
            Roles = new List<string>();
        }

        public string Id { get; set; }

        [Required]
        [ValidRNum(ErrorMessage = "R nummer moet aan het juist formaat voldoen. Vb: R0000001")]
        public string RNum { get; set; }

        [Required][EmailAddress]
        public string Email { get; set; }

        public IList<string> Roles { get; set; }
    }
}
