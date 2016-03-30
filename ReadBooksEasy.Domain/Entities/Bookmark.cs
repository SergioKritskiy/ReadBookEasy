﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ReadBooksEasy.Domain.Entities
{
    public class Bookmark
    {
        [Key]
        public int IdBookmark { get; set; }
        public int IdUser { get; set; }
        public int IdBook { get; set; }
        public int numberOfPage { get; set; }

        public virtual Book Book { get; set; }
    }
}
