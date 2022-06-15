using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bitcoin.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string EventName { get; set; }
        public string Date { get; set; }
        public string Link { get; set; }
        public string ImageLink { get; set; }
        public string Description { get; set; }
        public bool IsApproved { get; set; }
    }
}