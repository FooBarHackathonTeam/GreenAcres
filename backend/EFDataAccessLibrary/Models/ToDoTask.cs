﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Models
{
    public class ToDoTask
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        public string Type { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
    }
}
