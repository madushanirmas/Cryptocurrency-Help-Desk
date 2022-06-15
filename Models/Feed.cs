using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bitcoin.Models
{
    public class Feed
    {
        [Key]
        public int Id { get; set; }
        public int ForumId { get; set; }
        public string Description { get; set; }
        public string DateTime { get; set; }
    }
}