using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Bitcoin.Models
{
    public class Forum
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public string DateTime { get; set; }
        public string Owner { get; set; }

        public virtual List<Feed> Feeds { get; set; }
    }
}